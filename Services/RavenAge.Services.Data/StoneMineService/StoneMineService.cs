namespace RavenAge.Services.Data.StoneMineService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Http;
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class StoneMineService : IStoneMineService
    {
        private readonly IDeletableEntityRepository<StoneMine> stoneMineRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IHttpContextAccessor httpContextAccessor;

        public StoneMineService(
            IDeletableEntityRepository<StoneMine> stoneMineRepo,
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo,
            IHttpContextAccessor httpContextAccessor)
        {
            this.stoneMineRepo = stoneMineRepo;
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
            this.httpContextAccessor = httpContextAccessor;
        }

        public async Task StoneMineLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var stoneMine = this.stoneMineRepo.All().FirstOrDefault(x => x.Id == city.StoneMineId);
            var silverNeeded = stoneMine.SilverPrice;
            var woodNeeded = stoneMine.WoodPrice;
            var stoneNeeded = stoneMine.StonePrice;

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.Silver -= stoneMine.SilverPrice;
                city.Wood -= stoneMine.WoodPrice;
                city.Stone -= stoneMine.StonePrice;

                stoneMine.Level += 1;
                stoneMine.SilverPrice *= 2;
                stoneMine.WoodPrice *= 2;
                stoneMine.StonePrice *= 2;
                stoneMine.Production += GlobalConstants.SawMillProdictionPerLevel;
            }

            await this.stoneMineRepo.SaveChangesAsync();
            await this.cityRepo.SaveChangesAsync();
        }
    }
}
