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

        public async Task SawMillLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var woodMain = this.woodMineRepo.All().FirstOrDefault(x => x.Id == city.WoodMineId);
            var silverNeeded = woodMain.SilverPrice;
            var woodNeeded = woodMain.WoodPrice;
            var stoneNeeded = woodMain.StonePrice;

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= woodMain.SilverPrice;
                city.Wood -= woodMain.WoodPrice;
                city.Stone -= woodMain.StonePrice;

                woodMain.Level += 1;
                woodMain.SilverPrice *= 2;
                woodMain.WoodPrice *= 2;
                woodMain.StonePrice *= 2;
                woodMain.Production += GlobalConstants.SawMillProdictionPerLevel;
            }

            await this.woodMineRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();
        }
    }
}
