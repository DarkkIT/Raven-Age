namespace RavenAge.Services.Data.GuildService
{
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Guild;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class GuildService : IGuildService
    {
        private readonly IDeletableEntityRepository<Guild> guildRepo;
        private readonly IDeletableEntityRepository<ApplicationUser> userRepo;

        public GuildService(IDeletableEntityRepository<Guild> guildRepo, IDeletableEntityRepository<ApplicationUser> userRepo)
        {
            this.guildRepo = guildRepo;
            this.userRepo = userRepo;
        }

        public Task ApproveJoinGuild(int guildId)
        {
            throw new NotImplementedException();
        }

        public async Task Create(string userId, string guildName)
        {
            var guild = new Guild() { Name = guildName, GuildMasterId = userId };

            guild.Members.Add(this.userRepo.AllAsNoTracking().FirstOrDefault(x => x.Id == userId));
            await this.guildRepo.AddAsync(guild);
            await this.guildRepo.SaveChangesAsync();
        }

        public List<GuildViewModel> GetGuilds()
        {
            return this.guildRepo.All().To<GuildViewModel>().ToList();
        }

        public Task Join(string userId, int guildId)
        {
            throw new NotImplementedException();
        }

        public Task Leave(string userId, int guildId)
        {
            throw new NotImplementedException();
        }
    }
}
