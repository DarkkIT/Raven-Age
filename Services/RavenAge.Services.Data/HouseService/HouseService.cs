namespace RavenAge.Services.Data.HouseService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

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

        public async Task HouseLevelUp(string userId)
        {
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;
            var currentStone = city.Stone;

            var silverNeeded = city.House.SilverPrice;
            var woodNeeded = city.House.WoodPrice;
            var stoneNeeded = city.House.StonePrice;

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood && stoneNeeded <= currentStone)
            {
                city.House.Level += 1;
                city.House.SilverPrice *= 2;
                city.House.WoodPrice *= 2;
                city.House.StonePrice *= 2;
            }

            await this.cityRepo.SaveChangesAsync();
        }
    }
}
