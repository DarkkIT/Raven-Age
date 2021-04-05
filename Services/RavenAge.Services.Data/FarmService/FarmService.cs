namespace RavenAge.Services.Data.FarmService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Farm;

    public class FarmService : IFarmService
    {
        private readonly IDeletableEntityRepository<Farm> farmRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public FarmService(
            IDeletableEntityRepository<Farm> farmRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.farmRepo = farmRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<FarmUpgradeViewModel> FarmLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var farm = this.farmRepo.All().FirstOrDefault(x => x.Id == city.FarmId);
            var silverNeeded = farm.SilverPrice;
            var woodNeeded = farm.WoodPrice;
            var stoneNeeded = farm.StonePrice;

            var farmUpgradeData = new FarmUpgradeViewModel { IsUpgraded = false };

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= farm.SilverPrice;
                city.Wood -= farm.WoodPrice;
                city.Stone -= farm.StonePrice;

                farm.Level += 1;
                farm.SilverPrice *= 2;
                farm.WoodPrice *= 2;
                farm.StonePrice *= 2;
                farm.FoodProduction += GlobalConstants.FoodProductionPerLevel;

                farmUpgradeData.IsUpgraded = true;
                farmUpgradeData.CurrentProduction = farm.FoodProduction;
                farmUpgradeData.NextLevelProduction = farm.FoodProduction + GlobalConstants.FoodProductionPerLevel;
                farmUpgradeData.SilverUpgradeCost = farm.SilverPrice;
                farmUpgradeData.WoodUpgradeCost = farm.WoodPrice;
                farmUpgradeData.StoneUpgradeCost = farm.StonePrice;
            }

            await this.farmRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();

            return farmUpgradeData;
        }
    }
}
