namespace RavenAge.Services.Data.SawMillService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Sawmill;

    public class SawMillService : ISawMillService
    {
        private readonly IDeletableEntityRepository<WoodMine> woodMineRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public SawMillService(
            IDeletableEntityRepository<WoodMine> woodMineRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.woodMineRepo = woodMineRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<SawMillUpgradeViewModel> SawMillLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var woodMine = this.woodMineRepo.All().FirstOrDefault(x => x.Id == city.WoodMineId);
            var silverNeeded = woodMine.SilverPrice;
            var woodNeeded = woodMine.WoodPrice;
            var stoneNeeded = woodMine.StonePrice;

            var upgradeModelData = new SawMillUpgradeViewModel() { IsUpgraded = false };

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= woodMine.SilverPrice;
                city.Wood -= woodMine.WoodPrice;
                city.Stone -= woodMine.StonePrice;

                woodMine.Level += 1;
                woodMine.SilverPrice *= 2;
                woodMine.WoodPrice *= 2;
                woodMine.StonePrice *= 2;
                woodMine.Production += GlobalConstants.SawMillProdictionPerLevel;

                upgradeModelData.IsUpgraded = true;
                upgradeModelData.SilverUpgradeCost = woodMine.SilverPrice;
                upgradeModelData.WoodUpgradeCost = woodMine.WoodPrice;
                upgradeModelData.StoneUpgradeCost = woodMine.StonePrice;
                upgradeModelData.CurrentProduction = woodMine.Production;
                upgradeModelData.NextLevelProduction = woodMine.Production + GlobalConstants.SawMillProdictionPerLevel;
                upgradeModelData.SilverAvailable = city.Silver;
                upgradeModelData.WoodAvailable = city.Wood;
                upgradeModelData.StoneAvailable = city.Stone;
            }

            await this.woodMineRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();

            return upgradeModelData;
        }
    }
}
