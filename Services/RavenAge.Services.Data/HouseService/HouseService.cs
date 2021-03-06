namespace RavenAge.Services.Data.HouseService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.House;

    public class HouseService : IHouseService
    {
        private readonly IDeletableEntityRepository<House> houseRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public HouseService(
            IDeletableEntityRepository<House> houseRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.houseRepo = houseRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public async Task<HouseUpgradeViewModel> HouseLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var house = this.houseRepo.All().FirstOrDefault(x => x.Id == city.HouseId);
            var silverNeeded = house.SilverPrice;
            var woodNeeded = house.WoodPrice;
            var stoneNeeded = house.StonePrice;

            var upgradeModelData = new HouseUpgradeViewModel() { IsUpgraded = false };

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= house.SilverPrice;
                city.Wood -= house.WoodPrice;
                city.Stone -= house.StonePrice;
                city.Workers += 2; ////add workers

                house.Level += 1;
                house.SilverPrice *= 2;
                house.WoodPrice *= 2;
                house.StonePrice *= 2;
                house.WorkerLimit += GlobalConstants.WorkerLimitPerLevel;
                house.Production += 2; //workers

                upgradeModelData.IsUpgraded = true;
                upgradeModelData.WorkerLimit = house.WorkerLimit;
                upgradeModelData.CurrentWorkersCount = city.Workers;
                upgradeModelData.Production = house.Production;
                upgradeModelData.IncomePerWorker = 4;


                upgradeModelData.SilverUpgradeCost = house.SilverPrice;
                upgradeModelData.WoodUpgradeCost = house.WoodPrice;
                upgradeModelData.StoneUpgradeCost = house.StonePrice;

                upgradeModelData.SilverAvailable = city.Silver;
                upgradeModelData.WoodAvailable = city.Wood;
                upgradeModelData.StoneAvailable = city.Stone;
            }

            await this.houseRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();

            return upgradeModelData;
        }
    }
}
