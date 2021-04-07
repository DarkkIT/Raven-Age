namespace RavenAge.Services.Data.HangfireService.SawMill
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class SawMillHangfireService : ISawMillHangfireService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<WoodMine> woodMineReposistory;
        private readonly IRepository<UserCity> userCityRepository;

        public SawMillHangfireService(
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<WoodMine> woodMineReposistory,
            IRepository<UserCity> userCityRepository)
        {
            this.cityRepository = cityRepository;
            this.woodMineReposistory = woodMineReposistory;
            this.userCityRepository = userCityRepository;
        }

        public async Task FarmSaw()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                var woodMine = await this.woodMineReposistory.All().FirstOrDefaultAsync(x => x.Id == city.WoodMineId);
                city.Wood += woodMine.Production;

                this.cityRepository.SaveChangesAsync().GetAwaiter();
                this.woodMineReposistory.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
