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

            var attackerArmyTotalCount = attackerArmy.ArmyTotalCount;
            var defenderArmyTotalCount = defenderArmy.ArmyTotalCount;

            while (attackerArmy.ArmyTotalCount > 0 || defenderArmy.ArmyTotalCount > 0)
            {
                var attackerArchersCount = attackerArmy.ArchersCount;
                var attackerInfantryCount = attackerArmy.InfantryCount;
                var attackerCavaleryCount = attackerArmy.CavaleryCount;
                var attackerArtileryCount = attackerArmy.ArtiletyCount;
                attackerArmyTotalCount = attackerArchersCount + attackerInfantryCount + attackerCavaleryCount + attackerArtileryCount;

                var defenderArchersCount = defenderArmy.ArchersCount;
                var defenderInfantryCount = defenderArmy.InfantryCount;
                var defenderCavaleryCount = defenderArmy.CavaleryCount;
                var defenderArtileryCount = defenderArmy.ArtiletyCount;
                defenderArmyTotalCount = defenderArchersCount + defenderInfantryCount + defenderCavaleryCount + defenderArtileryCount;

                //// Phase 1 - Artilery attack enemy Artilery, then attack enemy Archers

                defenderArtileryCount = this.UnitAttack(defenderArmy.FullArtileryHealth * defenderArtileryCount, attackerArmy.FullArtileryAttack * attackerArtileryCount, defenderArmy.FullArtileryHealth);

                defenderArchersCount = this.UnitAttack(defenderArmy.FullArcherHealth * defenderArchersCount, attackerArmy.FullArtileryAttack * attackerArtileryCount, defenderArmy.FullArcherHealth);

                //// Phase 1.2 - enemy Artilery responds with the same attack

                attackerArtileryCount = this.UnitAttack(attackerArmy.FullArtileryHealth * attackerArtileryCount, defenderArmy.FullArtileryAttack * defenderArtileryCount, attackerArmy.FullArtileryHealth);

                attackerArchersCount = this.UnitAttack(attackerArmy.FullArcherHealth * attackerArchersCount, defenderArmy.FullArtileryAttack * defenderArtileryCount, attackerArmy.FullArcherHealth);

                //// Phase 2 - Archers attack enemy Infantry, then attack enemy Cavalery

                defenderInfantryCount = this.UnitAttack(defenderArmy.FullInfantryHealth * defenderInfantryCount, attackerArmy.FullArcherAttack * attackerArchersCount, defenderArmy.FullInfantryHealth);

                defenderCavaleryCount = this.UnitAttack(defenderArmy.FullCavaleryHealth * defenderCavaleryCount, attackerArmy.FullArcherAttack * attackerArchersCount, defenderArmy.FullCavaleryHealth);

                //// Phase 2.2 - enemy Archars responds with the same attack

                attackerInfantryCount = this.UnitAttack(attackerArmy.FullInfantryHealth * attackerInfantryCount, defenderArmy.FullArcherAttack * defenderArchersCount, attackerArmy.FullInfantryHealth);

                attackerCavaleryCount = this.UnitAttack(attackerArmy.FullCavaleryHealth * attackerCavaleryCount, defenderArmy.FullArcherAttack * defenderArchersCount, attackerArmy.FullCavaleryHealth);

                //// Phase 3 - Cavalery attack enemy Infantry, then attack enemy Cavalery

                defenderInfantryCount = this.UnitAttack(defenderArmy.FullInfantryHealth * defenderInfantryCount, attackerArmy.FullCavaleryAttack * attackerCavaleryCount, defenderArmy.FullInfantryHealth);

                defenderCavaleryCount = this.UnitAttack(defenderArmy.FullCavaleryHealth * defenderCavaleryCount, attackerArmy.FullCavaleryAttack * attackerCavaleryCount, defenderArmy.FullCavaleryHealth);

                //// Phase 3.2 - enemy Cavalery responds with the same attack

                attackerInfantryCount = this.UnitAttack(attackerArmy.FullInfantryHealth * attackerInfantryCount, defenderArmy.FullCavaleryAttack * defenderCavaleryCount, attackerArmy.FullInfantryHealth);

                attackerCavaleryCount = this.UnitAttack(attackerArmy.FullCavaleryHealth * attackerCavaleryCount, defenderArmy.FullCavaleryAttack * defenderCavaleryCount, attackerArmy.FullCavaleryHealth);

                //// Phase 4 - Infantry attack enemy Cvalery , then attack enemy Infantry

                defenderCavaleryCount = this.UnitAttack(defenderArmy.FullCavaleryHealth * defenderCavaleryCount, attackerArmy.FullInfantriAttack * attackerInfantryCount, defenderArmy.FullCavaleryHealth);

                defenderInfantryCount = this.UnitAttack(defenderArmy.FullInfantryHealth * defenderInfantryCount, attackerArmy.FullInfantriAttack * attackerInfantryCount, defenderArmy.FullInfantryHealth);

                //// Phase 4.2 - enemy Infantry responds with the same attack

                attackerCavaleryCount = this.UnitAttack(attackerArmy.FullCavaleryHealth * attackerCavaleryCount, defenderArmy.FullInfantriAttack * defenderInfantryCount, attackerArmy.FullCavaleryHealth);

                attackerInfantryCount = this.UnitAttack(attackerArmy.FullInfantryHealth * attackerInfantryCount, defenderArmy.FullInfantriAttack * defenderInfantryCount, attackerArmy.FullInfantryHealth);
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
