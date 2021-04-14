namespace RavenAge.Services.Data.HangfireService.House
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class HouseHangfireService : IHouseHangfireService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<House> houseRepository;
        private readonly IRepository<UserCity> userCityRepository;

        public HouseHangfireService(
            IDeletableEntityRepository<City> cityRepository,
            IRepository<UserCity> userCityRepository,
            IDeletableEntityRepository<House> houseRepository)
        {
            this.cityRepository = cityRepository;
            this.userCityRepository = userCityRepository;
            this.houseRepository = houseRepository;
        }

        public async Task FarmSilver()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                city.Silver += city.Workers * GlobalConstants.SilverPerWorker;

                this.cityRepository.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }

        public async Task FarmWorkers()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                var house = await this.houseRepository.All().FirstOrDefaultAsync(x => x.Id == city.HouseId);
                var newWorkersCount = city.Workers + (house.Level * GlobalConstants.IncomingWorkersPerHoure);
                if (newWorkersCount <= house.WorkerLimit)
                {
                    city.Workers += house.Level * GlobalConstants.IncomingWorkersPerHoure;
                    this.cityRepository.SaveChangesAsync().GetAwaiter();
                }

            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
