namespace TheDarkPortal.Data.Seeding
{
    using System;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.DependencyInjection;
    using RavenAge.Common;
    using RavenAge.Data;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
    using RavenAge.Data.Models.Models;
    using RavenAge.Data.Seeding;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.RuneService;

    public class UsersSeeder : ISeeder
    {
        public async Task SeedAsync(ApplicationDbContext dbContext, IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var cityService = serviceProvider.GetRequiredService<ICityService>();
            var runeService = serviceProvider.GetRequiredService<IRuneService>();

            await SeedUserAsync(userManager, runeService, cityService, "darkk@abv.bg");
            await SeedUserAsync(userManager, runeService, cityService, "misho@abv.bg");
            await SeedUserAsync(userManager, runeService,  cityService, "hristo@abv.bg");
            await SeedUserAsync(userManager, runeService,  cityService, "user1@abv.bg");
            await SeedUserAsync(userManager, runeService,  cityService, "user2@abv.bg");
            await SeedUserAsync(userManager, runeService, cityService,  "user3@abv.bg");
        }

        private static async Task SeedUserAsync(UserManager<ApplicationUser> userManager, IRuneService runeService, ICityService cityService, string username)
        {
            var user = await userManager.FindByNameAsync(username);
            if (user == null)
            {
                var appUser = new ApplicationUser();
                appUser.UserName = username;
                appUser.Email = username;
                appUser.Type = "Undead";
                appUser.Avatar = "Avatar1";
                appUser.Name = username.Replace("@abv.bg", string.Empty);
                var cityName = appUser.Name + "ville";

                var runeId = DateTime.UtcNow.Millisecond;
                var rune = new Rune {InfantryAttackRune = true, SilverRune = true };
                await runeService.AddRuneAsync(rune);

                IdentityResult result = new IdentityResult();

                if (username == "misho@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);
                }
                else if (username == "darkk@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);

                }
                else if (username == "hristo@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);

                }
                else if (username == "user1@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);

                }
                else if (username == "user2@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);
                }
                else if (username == "user3@abv.bg")
                {
                    result = userManager.CreateAsync(appUser, "123456").Result;
                    await cityService.CreateStartUpCity(appUser.Id, cityName, appUser.Avatar, rune.Id);
                }

                if (result.Succeeded)
                {
                    if (username == "darkk@abv.bg")
                    {
                        userManager.AddToRoleAsync(appUser, GlobalConstants.AdministratorRoleName).Wait();
                    }
                }
            }
        }
    }
}