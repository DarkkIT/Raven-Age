namespace RavenAge.Services.Data.ArenaBattleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Arena;

    public class ArenaBattleService : IArenaBattleService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IDeletableEntityRepository<Archers> archersRepo;
        private readonly IDeletableEntityRepository<Infantry> infatryRepo;
        private readonly IDeletableEntityRepository<Artillery> artilleryRepo;
        private readonly IDeletableEntityRepository<Cavalry> calalryRepo;

        public ArenaBattleService(
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo,
            IDeletableEntityRepository<Archers> archersRepo,
            IDeletableEntityRepository<Infantry> infatryRepo,
            IDeletableEntityRepository<Artillery> artilleryRepo,
            IDeletableEntityRepository<Cavalry> calalryRepo)
        {
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
            this.archersRepo = archersRepo;
            this.infatryRepo = infatryRepo;
            this.artilleryRepo = artilleryRepo;
            this.calalryRepo = calalryRepo;
        }

        public async Task<BattleResultViewModel> Attack(string attackerId, int defenderCityId)
        {
            var attackerCityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == attackerId).CityId; //// Need attacker City Id !

            var attackPriority = new List<UnitType>() {UnitType.Artillery, UnitType.Archers, UnitType.Cavalry, UnitType.Infantry};

            var userArmy = this.GetArmy(attackerCityId, attackPriority);
            var opponentArmy = this.GetArmy(defenderCityId, attackPriority);

            //// BattleLogic

            while (userArmy.TotalArmyCount > 0 && opponentArmy.TotalArmyCount > 0)
            {
                foreach (var unit in userArmy.Army.Where(x => x.Count > 0))
                {
                    var opponentDefendingUnit = SelectDefendingUnit(unit.AttackPriority, opponentArmy);
                   this.UnitAttack(unit.TotalUnitAttack, opponentDefendingUnit);

                    if (userArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }

                    // Opponent turn
                    var opponentAttackUnit = opponentArmy.Army.FirstOrDefault(x => x.Count > 0 && x.HasAttacked == false);
                    if (opponentAttackUnit != null)
                    {
                    var attackerDefendingUnit = SelectDefendingUnit(opponentAttackUnit.AttackPriority, userArmy);
                    this.UnitAttack(opponentAttackUnit.TotalUnitAttack, attackerDefendingUnit);
                    opponentAttackUnit.HasAttacked = true;
                    }

                    if (userArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }
                }

                while (opponentArmy.Army.Any(x => x.HasAttacked == false && x.Count > 0))
                {
                    var defenderAttackUnit = opponentArmy.Army.FirstOrDefault(x => x.Count > 0 && x.HasAttacked == false);
                    var attackerDefendingUnit = SelectDefendingUnit(defenderAttackUnit.AttackPriority, userArmy);
                    this.UnitAttack(defenderAttackUnit.TotalUnitAttack, attackerDefendingUnit);

                    if (userArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }
                }

                opponentArmy.Army.ForEach(x => { x.HasAttacked = false; });
            }

            var winner = userArmy.TotalArmyCount > 0 ? $"{attackerCityId} - winner" : $"{defenderCityId} - winner";

            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }

        private static BattleUnitDTO SelectDefendingUnit(List<UnitType> attackPriority, BattleArmyDTO defenderArmy)
        {
            BattleUnitDTO defendingUnit = null;
            for (int i = 0; i < 4; i++)
            {
                defendingUnit = defenderArmy.Army.FirstOrDefault(x => x.Type == attackPriority[i] && x.Count > 0);
                if (defendingUnit != null)
                {
                    break;
                }
            }

            return defendingUnit;
        }

        public void UnitAttack(int totalUnitAttack, BattleUnitDTO defendingUnit)
        {
            defendingUnit.Count = (defendingUnit.TotalUnitHealth - totalUnitAttack) / defendingUnit.SingleUnitHealth;

            if (totalUnitAttack - totalUnitAttack <= 0)
            {
                defendingUnit.Count = 0;
            }

        }

        private BattleArmyDTO GetArmy(int userCityId, List<UnitType> attackPriority)
        {
            var userArmy = new BattleArmyDTO();
            var userArchers = this.archersRepo.AllAsNoTracking().Where(x => x.CityId == userCityId).To<BattleUnitDTO>().FirstOrDefault();
            userArchers.Type = UnitType.Archers;
            userArchers.AttackPriority = attackPriority;

            var userInfantry = this.infatryRepo.AllAsNoTracking().Where(x => x.CityId == userCityId).To<BattleUnitDTO>().FirstOrDefault();
            userInfantry.Type = UnitType.Infantry;
            userInfantry.AttackPriority = attackPriority;

            var userCavalry = this.calalryRepo.AllAsNoTracking().Where(x => x.CityId == userCityId).To<BattleUnitDTO>().FirstOrDefault();
            userCavalry.Type = UnitType.Cavalry;
            userCavalry.AttackPriority = attackPriority;

            var userArtillery = this.artilleryRepo.AllAsNoTracking().Where(x => x.CityId == userCityId).To<BattleUnitDTO>().FirstOrDefault();
            userArtillery.Type = UnitType.Artillery;
            userArtillery.AttackPriority = attackPriority;

            userArmy.Army.Add(userArchers);
            userArmy.Army.Add(userInfantry);
            userArmy.Army.Add(userCavalry);
            userArmy.Army.Add(userArtillery);

            return userArmy;
        }
    }
}
