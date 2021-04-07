namespace RavenAge.Services.Data.HangfireService
{
    using Microsoft.AspNetCore.Http;
    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models;
    using RavenAge.Data.Models.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;

    public class StoneMineHangfireJobService : IStoneMineHangfireJobService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<StoneMine> stoneMineReposistory;
        private readonly IRepository<UserCity> userCityRepository;


        public StoneMineHangfireJobService(
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<StoneMine> stoneMineReposistory,
            IRepository<UserCity> userCityRepository)
        {
            this.cityRepository = cityRepository;
            this.stoneMineReposistory = stoneMineReposistory;
            this.userCityRepository = userCityRepository;
        }

        public async Task FarmStone()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                var stoneMine = await this.stoneMineReposistory.All().FirstOrDefaultAsync(x => x.Id == city.StoneMineId);
                city.Stone += stoneMine.Production;

                this.cityRepository.SaveChangesAsync().GetAwaiter();
                this.stoneMineReposistory.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
