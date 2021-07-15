namespace RavenAge.Services.Data.ArenaBattleService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using AutoMapper;
    using Microsoft.AspNetCore.Identity;
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
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
        private readonly IRepository<UserBattle> userBattleRepo;
        private readonly IMapper mapper;
        private readonly UserManager<ApplicationUser> userManager;

        public ArenaBattleService(
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo,
            IDeletableEntityRepository<Archers> archersRepo,
            IDeletableEntityRepository<Infantry> infatryRepo,
            IDeletableEntityRepository<Artillery> artilleryRepo,
            IDeletableEntityRepository<Cavalry> calalryRepo,
            IRepository<UserBattle> userBattleRepo,
            IMapper mapper,
            UserManager<ApplicationUser> userManager
            )
        {
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
            this.archersRepo = archersRepo;
            this.infatryRepo = infatryRepo;
            this.artilleryRepo = artilleryRepo;
            this.calalryRepo = calalryRepo;
            this.userBattleRepo = userBattleRepo;
            this.mapper = mapper;
            this.userManager = userManager;
        }

        public async Task<BattleResultViewModel> Attack(string attackerId, int defenderCityId)
        {
            var attackerCityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == attackerId).CityId; //// Need attacker City Id !
            var defenderId = this.userCityRepo.All().FirstOrDefault(x => x.CityId == defenderCityId).UserId;
            // Attack priority should come as an input
            var attackPriority = new List<UnitType>() { UnitType.Artillery, UnitType.Archers, UnitType.Cavalry, UnitType.Infantry };

            var attackPriority = new List<UnitType>() {UnitType.Artillery, UnitType.Archers, UnitType.Cavalry, UnitType.Infantry};

            var userArmy = this.GetArmy(attackerCityId, attackPriority);
            var opponentArmy = this.GetArmy(defenderCityId, attackPriority);
            var battleResult = this.SetInitialBattleResultData(attackerArmy, opponentArmy, attackerId, defenderId);
            var battleReport = new List<string>();

            var attacker = await this.userManager.FindByIdAsync(attackerId);
            var defender = await this.userManager.FindByIdAsync(defenderId);

            //// BattleLogic

            while (attackerArmy.TotalArmyCount > 0 && opponentArmy.TotalArmyCount > 0)
            {
                foreach (var unit in attackerArmy.Army.Where(x => x.Count > 0))
                {
                    var opponentDefendingUnit = SelectDefendingUnit(unit.AttackPriority, opponentArmy);
                   this.UnitAttack(unit.TotalUnitAttack, opponentDefendingUnit);

                    if (attackerArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }

                    // Opponent turn
                    var opponentAttackUnit = opponentArmy.Army.FirstOrDefault(x => x.Count > 0 && x.HasAttacked == false);
                    if (opponentAttackUnit != null)
                    {
                        var attackerDefendingUnit = SelectDefendingUnit(opponentAttackUnit.AttackPriority, attackerArmy);
                        this.UnitAttack(opponentAttackUnit.TotalUnitAttack, attackerDefendingUnit);

                        UpdateBattleReport(battleReport, opponentAttackUnit, attackerDefendingUnit, defender, attacker);

                        opponentAttackUnit.HasAttacked = true;
                    }

                    if (attackerArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }
                }

                while (opponentArmy.Army.Any(x => x.HasAttacked == false && x.Count > 0))
                {
                    var opponentAttackUnit = opponentArmy.Army.FirstOrDefault(x => x.Count > 0 && x.HasAttacked == false);
                    var attackerDefendingUnit = SelectDefendingUnit(opponentAttackUnit.AttackPriority, attackerArmy);
                    this.UnitAttack(opponentAttackUnit.TotalUnitAttack, attackerDefendingUnit);
                    UpdateBattleReport(battleReport, opponentAttackUnit, attackerDefendingUnit, defender, attacker);


                    if (attackerArmy.TotalArmyCount == 0 || opponentArmy.TotalArmyCount == 0)
                    {
                        break;
                    }
                }

                opponentArmy.Army.ForEach(x => { x.HasAttacked = false; });
            }

            UpdateBattleResult(attackerId, defenderId, attackerArmy, opponentArmy, battleResult);
            var userBattle = new UserBattle() { BattleResult = battleResult, UserId = attackerId };
            await this.userBattleRepo.AddAsync(userBattle);
            await this.userBattleRepo.SaveChangesAsync();

            var result = this.mapper.Map<BattleResultViewModel>(battleResult);
            result.BattleReport = battleReport;

            return result;
        }

        private static void UpdateBattleReport(List<string> battleReport, BattleUnitDTO attackingUnit, BattleUnitDTO defendingUnit, ApplicationUser attacker, ApplicationUser defender)
        {
            battleReport.Add($"{attacker.Name}'s {attackingUnit.Type} attacked {defender.Name}'s {defendingUnit.Type} and did {attackingUnit.TotalUnitAttack} dmg!");
        }

        public void UnitAttack(int totalUnitAttack, BattleUnitDTO defendingUnit)
        {
            defendingUnit.Count = (defendingUnit.TotalUnitHealth - totalUnitAttack) / defendingUnit.SingleUnitHealth;

            if (totalUnitAttack - totalUnitAttack <= 0)
            {
                defendingUnit.Count = 0;
            }

        }

        private static void UpdateBattleResult(string attackerId, string defenderId, BattleArmyDTO attackerArmy, BattleArmyDTO opponentArmy, BattleResult battleResult)
        {
            battleResult.Winner = attackerArmy.TotalArmyCount > 0 ? attackerId : defenderId;
            battleResult.AttackerArchersLost = battleResult.AttackerArchers - attackerArmy.Army.FirstOrDefault(x => x.Type == UnitType.Archers).Count;
            battleResult.AttackerArtilleryLost = battleResult.AttackerArtillery - attackerArmy.Army.FirstOrDefault(x => x.Type == UnitType.Artillery).Count;
            battleResult.AttackerCavalryLost = battleResult.AttackerCavalry - attackerArmy.Army.FirstOrDefault(x => x.Type == UnitType.Cavalry).Count;
            battleResult.AttackerInfantryLost = battleResult.AttackerInfantry - attackerArmy.Army.FirstOrDefault(x => x.Type == UnitType.Infantry).Count;

            battleResult.DefenderArchersLost = battleResult.DefenderArchers - opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Archers).Count;
            battleResult.DefenderArtilleryLost = battleResult.DefenderArtillery - opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Artillery).Count;
            battleResult.DefenderCavalryLost = battleResult.DefenderCavalry - opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Cavalry).Count;
            battleResult.DefenderInfantryLost = battleResult.DefenderInfantry - opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Infantry).Count;
        }

        private BattleResult SetInitialBattleResultData(BattleArmyDTO userArmy, BattleArmyDTO opponentArmy, string attackerId, string defenderId)
        {
            var battleResult = new BattleResult();
            battleResult.Attacker = attackerId;
            battleResult.Defender = defenderId;
            battleResult.BattleType = "Arena";
            battleResult.AttackerArchers = userArmy.Army.FirstOrDefault(x => x.Type == UnitType.Archers).Count;
            battleResult.AttackerArtillery = userArmy.Army.FirstOrDefault(x => x.Type == UnitType.Artillery).Count;
            battleResult.AttackerCavalry = userArmy.Army.FirstOrDefault(x => x.Type == UnitType.Cavalry).Count;
            battleResult.AttackerInfantry = userArmy.Army.FirstOrDefault(x => x.Type == UnitType.Infantry).Count;
            battleResult.DefenderArchers = opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Archers).Count;
            battleResult.DefenderArtillery = opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Artillery).Count;
            battleResult.DefenderCavalry = opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Cavalry).Count;
            battleResult.DefenderInfantry = opponentArmy.Army.FirstOrDefault(x => x.Type == UnitType.Infantry).Count;

            return battleResult;
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
