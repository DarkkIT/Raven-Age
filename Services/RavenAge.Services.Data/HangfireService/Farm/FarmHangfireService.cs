namespace RavenAge.Services.Data.HangfireService.Farm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class FarmHangfireService : IFarmHangfireService
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IDeletableEntityRepository<Farm> farmMineReposistory;
        private readonly IRepository<UserCity> userCityRepository;
        private readonly IRepository<Rune> runeRepository;


        public FarmHangfireService(
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<Farm> farmMineReposistory,
            IRepository<UserCity> userCityRepository,
            IRepository<Rune> runeRepository)
        {
            this.cityRepository = cityRepository;
            this.farmMineReposistory = farmMineReposistory;
            this.userCityRepository = userCityRepository;
            this.runeRepository = runeRepository;
        }

        public async Task FarmFood()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                var farmMine = await this.farmMineReposistory.All().FirstOrDefaultAsync(x => x.Id == city.FarmId);
                var rune = await this.runeRepository.All().FirstOrDefaultAsync(x => x.Id == city.RuneId);
                if (rune.FoodRunes)
                {
                    // 10percantage plus if the user have the food Rune
                    var plusPercentage = ((double)farmMine.FoodProduction / 100.0) * 10.0;
                    city.Food += farmMine.FoodProduction + (decimal)plusPercentage;
                }
                else
                {
                    city.Food += farmMine.FoodProduction;
                }

                this.cityRepository.SaveChangesAsync().GetAwaiter();
                this.farmMineReposistory.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
