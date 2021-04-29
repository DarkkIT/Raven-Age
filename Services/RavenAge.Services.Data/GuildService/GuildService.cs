namespace RavenAge.Services.Data.GuildService
{
    using RavenAge.Data.Common.Repositories;
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

        public GuildService(IDeletableEntityRepository<Guild> guildRepo)
        {
            this.guildRepo = guildRepo;
        }

        public Task ApproveJoinGuild(int guildId)
        {
            throw new NotImplementedException();
        }

        public Task Create(int userId)
        {
            throw new NotImplementedException();
        }

        public List<GuildViewModel> GetGuilds()
        {
            return this.guildRepo.All().To<GuildViewModel>().ToList();
        }

        public Task Join(int userId, int guildId)
        {
            throw new NotImplementedException();
        }

        public Task Leave(int userId, int guildId)
        {
            throw new NotImplementedException();
        }
    }
}
