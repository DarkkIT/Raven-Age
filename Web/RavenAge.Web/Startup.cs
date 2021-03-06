namespace RavenAge.Web
{
    using System;
    using System.Collections.Generic;
    using System.Reflection;
    using System.Threading.Tasks;

    using Hangfire;
    using Hangfire.SqlServer;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Filters;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using Newtonsoft.Json;
    using RavenAge.Data;
    using RavenAge.Data.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
    using RavenAge.Data.Repositories;
    using RavenAge.Data.Seeding;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.ArenaBattleService;
    using RavenAge.Services.Data.ArenaService;
    using RavenAge.Services.Data.BarracksService;
    using RavenAge.Services.Data.DefenceWall;
    using RavenAge.Services.Data.FarmService;
    using RavenAge.Services.Data.GuildService;
    using RavenAge.Services.Data.HangfireService;
    using RavenAge.Services.Data.HangfireService.Farm;
    using RavenAge.Services.Data.HangfireService.House;
    using RavenAge.Services.Data.HangfireService.SawMill;
    using RavenAge.Services.Data.HangfireService.TaxesArmy;
    using RavenAge.Services.Data.HouseService;
    using RavenAge.Services.Data.RuneService;
    using RavenAge.Services.Data.SawMillService;
    using RavenAge.Services.Data.StoneMineService;
    using RavenAge.Services.Data.TownhallService;
    using RavenAge.Services.Mapping;
    using RavenAge.Services.Messaging;
    using RavenAge.Services.UserService.Data;
    using RavenAge.Web.Infrastructure;
    using RavenAge.Web.ViewModels;

    public class Startup
    {
        private readonly IConfiguration configuration;

        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(
                options => options.UseSqlServer(this.configuration.GetConnectionString("DefaultConnection")));

            services.AddDefaultIdentity<ApplicationUser>(IdentityOptionsProvider.GetIdentityOptions)
                .AddRoles<ApplicationRole>().AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<CookiePolicyOptions>(
                options =>
                    {
                        options.CheckConsentNeeded = context => true;
                        options.MinimumSameSitePolicy = SameSiteMode.None;
                    });
            services.AddControllersWithViews(
                options =>
                    {
                        options.Filters.Add(new AutoValidateAntiforgeryTokenAttribute());
                    }).AddRazorRuntimeCompilation();
            services.AddRazorPages();
            services.AddAntiforgery(options =>
            {
                options.HeaderName = "X-CSRF-TOKEN";
            });
            services.AddMvc().AddRazorPagesOptions(options =>
            {
                options.Conventions.AddAreaPageRoute("/Home", "/Index", "");
            }).SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddDatabaseDeveloperPageExceptionFilter();
            services.AddAutoMapper(typeof(BattleResultProfile));
            services.AddSingleton(this.configuration);

            // Data repositories
            services.AddScoped(typeof(IDeletableEntityRepository<>), typeof(EfDeletableEntityRepository<>));
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IDbQueryRunner, DbQueryRunner>();

            // Application services
            services.AddTransient<IEmailSender, NullMessageSender>();
            services.AddTransient<ICityService, CityService>();
            services.AddTransient<IBarracksService, BarracksService>();
            services.AddTransient<IHouseService, HouseService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IFarmService, FarmService>();
            services.AddTransient<ISawMillService, SawMillService>();
            services.AddTransient<ITownHallService, TownHallService>();
            services.AddTransient<IStoneMineService, StoneMineService>();
            services.AddTransient<IDefenceWallService, DefenceWallService>();
            services.AddTransient<IRuneService, RuneService>();
            services.AddTransient<IArenaService, ArenaService>();
            services.AddTransient<IGuildService, GuildService>();
            services.AddTransient<IArenaBattleService, ArenaBattleService>();

            // HangfireServices
            services.AddHangfire(config =>
            {
                // ReferenceLoop Fixing json error for resetStats on the player
                config.UseSerializerSettings(new JsonSerializerSettings() { ReferenceLoopHandling = ReferenceLoopHandling.Ignore });
                config.SetDataCompatibilityLevel(CompatibilityLevel.Version_110);
                config.UseSimpleAssemblyNameTypeSerializer();
                config.UseRecommendedSerializerSettings()
                .UseSqlServerStorage(
                this.configuration.GetConnectionString("DefaultConnection"),
                new SqlServerStorageOptions
                {
                    CommandBatchMaxTimeout = TimeSpan.FromMinutes(5),
                    SlidingInvisibilityTimeout = TimeSpan.FromMinutes(5),
                    PrepareSchemaIfNecessary = true,
                    QueuePollInterval = TimeSpan.Zero,
                    UseRecommendedIsolationLevel = true,
                    UsePageLocksOnDequeue = true,
                    DisableGlobalLocks = true,
                });
            });

            services.AddHangfireServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IRecurringJobManager recurringJob)
        {
            AutoMapperConfig.RegisterMappings(typeof(ErrorViewModel).GetTypeInfo().Assembly);

            // Seed data on application startup
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
                dbContext.Database.Migrate();
                new ApplicationDbContextSeeder().SeedAsync(dbContext, serviceScope.ServiceProvider).GetAwaiter().GetResult();
                this.SeedHangfireJobs(recurringJob);
            }

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseRouting();

            app.UseHangfireDashboard();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(
                endpoints =>
                    {
                        endpoints.MapControllerRoute("areaRoute", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
                        endpoints.MapRazorPages();
                    });
        }

        public async Task SeedHangfireJobs(IRecurringJobManager recurringJob)
        {
            recurringJob.AddOrUpdate<StoneMineHangfireJobService>("StoneMineHangfireJobService", x => x.FarmStone(), Cron.Hourly);
            recurringJob.AddOrUpdate<SawMillHangfireService>("SawMillHangfireService", x => x.FarmSaw(), Cron.Hourly);
            recurringJob.AddOrUpdate<FarmHangfireService>("FarmHangfireService", x => x.FarmFood(), Cron.Hourly);
            recurringJob.AddOrUpdate<HouseHangfireService>("HouseHangfireService", x => x.FarmSilver(), Cron.Hourly);
            recurringJob.AddOrUpdate<HouseHangfireService>("HouseHangfireService", x => x.FarmWorkers(), Cron.Hourly);
            recurringJob.AddOrUpdate<TaxArmy>("TaxArmy", x => x.GetTaxesFromArmy(), Cron.Hourly);
        }
    }
}
