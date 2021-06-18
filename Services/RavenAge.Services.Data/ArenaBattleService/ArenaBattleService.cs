namespace RavenAge.Services.Data.ArenaBattleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Arena;

    public class ArenaBattleService : IArenaBattleService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IDeletableEntityRepository<Archers> archersRepo;

        public ArenaBattleService(
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo,
            IDeletableEntityRepository<Archers> archersRepo)
        {
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
            this.archersRepo = archersRepo;
        }

        public async Task<BattleResultViewModel> Attack(string attackerId, int defenderId)
        {
            var userCity = this.userCityRepo.All().FirstOrDefault(x => x.UserId == attackerId); //// Need attacker City Id !

            var attackerCity = this.cityRepo.All().Where(x => x.Id == userCity.CityId).To<ArenaArmyDTO>().FirstOrDefault();

            var defenderCity = this.cityRepo.All().Where(x => x.Id == defenderId).To<ArenaArmyDTO>().FirstOrDefault();

            //// BattleLogic

            //while (attackerCity.ArmyTotalCount <= 0 || defenderCity.ArmyTotalCount <= 0)
            //{

            //}

            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }
    }
}
