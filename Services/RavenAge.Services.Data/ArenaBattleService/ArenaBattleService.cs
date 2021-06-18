namespace RavenAge.Services.Data.ArenaBattleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Arena;

    public class ArenaBattleService : IArenaBattleService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public ArenaBattleService(
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<BattleResultViewModel> Attack(string attackerId, int defenderId)
        {
            var userCity = this.userCityRepo.All().FirstOrDefault(x => x.UserId == attackerId);

            var attackerCity = this.cityRepo.All().FirstOrDefault(x => x.Id == userCity.CityId);
            var defenderCity = this.cityRepo.All().FirstOrDefault(x => x.Id == defenderId);

            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }
    }
}
