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

            var attackerArmyTotalCount = attackerCity.ArmyTotalCount;
            var defenderArmyTotalCount = defenderCity.ArmyTotalCount;

            while (attackerArmyTotalCount > 0 || defenderArmyTotalCount > 0)
            {
                var attackerArchersCount = attackerCity.ArchersCount;
                var attackerInfantryCount = attackerCity.InfantryCount;
                var attackerCavaleryCount = attackerCity.CavaleryCount;
                var attackerArtileryCount = attackerCity.ArtiletyCount;
                attackerArmyTotalCount = attackerArchersCount + attackerInfantryCount + attackerCavaleryCount + attackerArtileryCount;

                var defenderArchersCount = defenderCity.ArchersCount;
                var defenderInfantryCount = defenderCity.InfantryCount;
                var defenderCavaleryCount = defenderCity.CavaleryCount;
                var defenderArtileryCount = defenderCity.ArtiletyCount;
                defenderArmyTotalCount = defenderArchersCount + defenderInfantryCount + defenderCavaleryCount + defenderArtileryCount;

                //// Phase 1 - Artilery attack enemy Artilery, then attack enemy Archers

                var defenderArtileryHealtLeft =
                    (defenderCity.FullArtileryHealth * defenderArtileryCount)
                    - (attackerCity.FullArtileryAttack * attackerArtileryCount);

                defenderArtileryCount = defenderArtileryHealtLeft / defenderCity.FullArtileryHealth;

                var defenderArchersHeltLeft =
                    (defenderCity.FullArcherHealth * defenderArchersCount)
                    - (attackerCity.FullArtileryAttack * attackerArtileryCount);

                defenderArchersCount = defenderArchersHeltLeft / defenderCity.FullArcherHealth;

                //// Phase 2 - enemy Artilery responds with the same attack

                var attackerArtileryHelthLeft =
                    (attackerCity.FullArtileryHealth * attackerArtileryCount)
                    - (defenderCity.FullArtileryAttack * defenderArtileryCount);

                attackerArtileryCount = attackerArtileryHelthLeft / attackerCity.FullArtileryHealth;

                var attackerArchersHealthLeft =
                    (attackerCity.FullArcherHealth * attackerArchersCount)
                    - (defenderCity.FullArtileryAttack * defenderArtileryCount);

                attackerArchersCount = attackerArchersHealthLeft / attackerCity.FullArcherHealth;
            }

            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }
    }
}
