namespace RavenAge.Services.Data.TownhallService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.TownHall;

    public class TownHallService : ITownHallService
    {
        private readonly IDeletableEntityRepository<TownHall> townHallRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public TownHallService(
            IDeletableEntityRepository<TownHall> townHallRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.townHallRepo = townHallRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<TownHallUpgradeViewModel> TownHallLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var townHall = this.townHallRepo.All().FirstOrDefault(x => x.Id == city.HouseId);
            var silverNeeded = townHall.SilverPrice;
            var woodNeeded = townHall.WoodPrice;
            var stoneNeeded = townHall.StonePrice;

            var townHallUpgradeData = new TownHallUpgradeViewModel { IsUpgraded = false};

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= townHall.SilverPrice;
                city.Wood -= townHall.WoodPrice;
                city.Stone -= townHall.StonePrice;

                townHall.Level += 1;
                townHall.SilverPrice *= 2;
                townHall.WoodPrice *= 2;
                townHall.StonePrice *= 2;
                townHall.ArmyLimit += GlobalConstants.TownHallArmyLimitPerLevel;

                townHallUpgradeData.IsUpgraded = true;
                townHallUpgradeData.SilverAvailable = city.Silver;
                townHallUpgradeData.WoodAvailable = city.Wood;
                townHallUpgradeData.StoneAvailable = city.Stone;
                townHallUpgradeData.SilverUpgradeCost = townHall.SilverPrice;
                townHallUpgradeData.WoodUpgradeCost = townHall.WoodPrice;
                townHallUpgradeData.StoneUpgradeCost = townHall.StonePrice;
                townHallUpgradeData.ArmyLimit = townHall.ArmyLimit;
            }

            await this.townHallRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();

            return townHallUpgradeData;
        }
    }
}
