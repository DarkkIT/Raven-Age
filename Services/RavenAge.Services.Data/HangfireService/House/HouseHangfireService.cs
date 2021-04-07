namespace RavenAge.Services.Data.HangfireService.House
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class HouseHangfireService : IHouseHangfireService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IRepository<UserCity> userCityRepository;

        public HouseHangfireService(
            IDeletableEntityRepository<City> cityRepository,
            IRepository<UserCity> userCityRepository)
        {
            this.cityRepository = cityRepository;
            this.userCityRepository = userCityRepository;
        }

        public async Task FarmWorkers()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                city.Silver += city.Workers * 4; // 4 is income silver per Worker

                this.cityRepository.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
