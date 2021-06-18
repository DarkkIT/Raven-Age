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

            var attackerArmy = this.cityRepo.All().Where(x => x.Id == userCity.CityId).To<ArenaArmyDTO>().FirstOrDefault();

            var defenderArmy = this.cityRepo.All().Where(x => x.Id == defenderId).To<ArenaArmyDTO>().FirstOrDefault();

            //// BattleLogic

            //var attackerArmyTotalCount = attackerArmy.ArmyTotalCount;
            //var defenderArmyTotalCount = defenderArmy.ArmyTotalCount;

            while (attackerArmy.ArmyTotalCount > 0 || defenderArmy.ArmyTotalCount > 0)
            {
                //var attackerArchersCount = attackerArmy.ArchersCount;
                //var attackerInfantryCount = attackerArmy.InfantryCount;
                //var attackerCavaleryCount = attackerArmy.CavalryCount;
                //var attackerArtileryCount = attackerArmy.ArtilleryCount;
                //attackerArmyTotalCount = attackerArchersCount + attackerInfantryCount + attackerCavaleryCount + attackerArtileryCount;

                //var defenderArchersCount = defenderArmy.ArchersCount;
                //var defenderInfantryCount = defenderArmy.InfantryCount;
                //var defenderCavaleryCount = defenderArmy.CavalryCount;
                //var defenderArtileryCount = defenderArmy.ArtilleryCount;
                //defenderArmyTotalCount = defenderArchersCount + defenderInfantryCount + defenderCavaleryCount + defenderArtileryCount;

                //// Phase 1 - Artilery attack enemy Artilery, then attack enemy Archers

                defenderArmy.ArtilleryCount = this.UnitAttack(defenderArmy.TotalArtilleryHealth, attackerArmy.TotalArtilleryAttack, defenderArmy.SingleArtilleryHealth);

                defenderArmy.ArchersCount = this.UnitAttack(defenderArmy.TotalArcherHealth, attackerArmy.TotalArtilleryAttack, defenderArmy.SingleArcherHealth);

                //// Phase 1.2 - enemy Artilery responds with the same attack

                attackerArmy.ArtilleryCount = this.UnitAttack(attackerArmy.TotalArtilleryHealth, defenderArmy.TotalArtilleryAttack, attackerArmy.SingleArtilleryHealth);

                attackerArmy.ArchersCount = this.UnitAttack(attackerArmy.TotalArcherHealth, defenderArmy.TotalArtilleryAttack, attackerArmy.SingleArcherHealth);

                //// Phase 2 - Archers attack enemy Infantry, then attack enemy Cavalery

                defenderArmy.InfantryCount = this.UnitAttack(defenderArmy.TotalInfantryHealth, attackerArmy.TotalArcherAttack, defenderArmy.SingleInfantryHealth);

                defenderArmy.CavalryCount = this.UnitAttack(defenderArmy.TotalCavalryHealth, attackerArmy.TotalArcherAttack, defenderArmy.SingleCavalryHealth);

                //// Phase 2.2 - enemy Archars responds with the same attack

                attackerArmy.InfantryCount = this.UnitAttack(attackerArmy.TotalInfantryHealth, defenderArmy.TotalArcherAttack, attackerArmy.SingleInfantryHealth);

                attackerArmy.CavalryCount = this.UnitAttack(attackerArmy.TotalCavalryHealth, defenderArmy.TotalArcherAttack, attackerArmy.SingleCavalryHealth);

                //// Phase 3 - Cavalery attack enemy Infantry, then attack enemy Cavalery

                defenderArmy.InfantryCount = this.UnitAttack(defenderArmy.TotalInfantryHealth, attackerArmy.TotalCavalryAttack, defenderArmy.SingleInfantryHealth);

                defenderArmy.CavalryCount = this.UnitAttack(defenderArmy.TotalCavalryHealth, attackerArmy.TotalCavalryAttack, defenderArmy.SingleCavalryHealth);

                //// Phase 3.2 - enemy Cavalery responds with the same attack

                attackerArmy.InfantryCount = this.UnitAttack(attackerArmy.TotalInfantryHealth, defenderArmy.TotalCavalryAttack, attackerArmy.SingleInfantryHealth);

                attackerArmy.CavalryCount = this.UnitAttack(attackerArmy.TotalCavalryHealth, defenderArmy.TotalCavalryAttack, attackerArmy.SingleCavalryHealth);

                //// Phase 4 - Infantry attack enemy Cavalry , then attack enemy Infantry

                defenderArmy.CavalryCount = this.UnitAttack(defenderArmy.TotalCavalryHealth, attackerArmy.TotalInfantryAttack, defenderArmy.SingleCavalryHealth);

                defenderArmy.InfantryCount = this.UnitAttack(defenderArmy.TotalInfantryHealth, attackerArmy.TotalInfantryHealth, defenderArmy.SingleInfantryHealth);

                //// Phase 4.2 - enemy Infantry responds with the same attack

                attackerArmy.CavalryCount = this.UnitAttack(attackerArmy.TotalCavalryHealth, defenderArmy.TotalInfantryAttack, attackerArmy.SingleCavalryHealth);

                attackerArmy.InfantryCount = this.UnitAttack(attackerArmy.TotalInfantryHealth, defenderArmy.TotalInfantryAttack, attackerArmy.SingleInfantryHealth);
            }

            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }

        public int UnitAttack(int totalUnitHealth, int totalUnitAttack, int singleUnitHealth)
        {
            var defenderUnitHealtLeft =
                    totalUnitHealth - totalUnitAttack;

            return defenderUnitHealtLeft / singleUnitHealth;
        }
    }
}
