namespace RavenAge.Services.Data.DefenceWall
{
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.DefenceWall;

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class DefenceWallService : IDefenceWallService
    {
        private readonly IDeletableEntityRepository<DefenceWall> defenceWallRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public DefenceWallService(
            IDeletableEntityRepository<DefenceWall> defenceWallRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.defenceWallRepo = defenceWallRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<DefenceWallUpgradeViewModel> DefenceWallLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var defenceWall = this.defenceWallRepo.All().FirstOrDefault(x => x.Id == city.DefenceWallId);
            var silverNeeded = defenceWall.SilverPrice;
            var woodNeeded = defenceWall.WoodPrice;
            var stoneNeeded = defenceWall.StonePrice;

            var defenceWallUpgradeData = new DefenceWallUpgradeViewModel() { IsUpgraded = false };

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= defenceWall.SilverPrice;
                city.Wood -= defenceWall.WoodPrice;
                city.Stone -= defenceWall.StonePrice;

                defenceWall.Level += 1;
                defenceWall.SilverPrice *= 2;
                defenceWall.WoodPrice *= 2;
                defenceWall.StonePrice *= 2;
                defenceWall.Defence += GlobalConstants.DefencePerLevel;

                defenceWallUpgradeData.IsUpgraded = true;
                defenceWallUpgradeData.Level = defenceWall.Level;
                defenceWallUpgradeData.DefencePoints = defenceWall.Defence;

                defenceWallUpgradeData.SilverUpgradeCost = defenceWall.SilverPrice;
                defenceWallUpgradeData.WoodUpgradeCost = defenceWall.WoodPrice;
                defenceWallUpgradeData.StoneUpgradeCost = defenceWall.StonePrice;

                defenceWallUpgradeData.SilverAvailable = city.Silver;
                defenceWallUpgradeData.WoodAvailable = city.Wood;
                defenceWallUpgradeData.StoneAvailable = city.Stone;
            }

            await this.defenceWallRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();
            return defenceWallUpgradeData;
        }
    }
}