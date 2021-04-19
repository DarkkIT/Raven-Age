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
        private readonly IRepository<Rune> runeRepository;

        public SawMillHangfireService(
            IDeletableEntityRepository<City> cityRepository,
            IDeletableEntityRepository<WoodMine> woodMineReposistory,
            IRepository<UserCity> userCityRepository,
            IRepository<Rune> runeRepository)
        {
            this.cityRepository = cityRepository;
            this.woodMineReposistory = woodMineReposistory;
            this.userCityRepository = userCityRepository;
            this.runeRepository = runeRepository;
        }

        public async Task FarmSaw()
        {
            var userCity = this.userCityRepository.All();

            foreach (var user in userCity)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == user.CityId);
                var woodMine = await this.woodMineReposistory.All().FirstOrDefaultAsync(x => x.Id == city.WoodMineId);
                var rune = await this.runeRepository.All().FirstOrDefaultAsync(x => x.Id == city.RuneId);
                if (rune.WoodRune)
                {
                    var plusPercentage = ((double)woodMine.Production / 100.0) * 10.0;
                    city.Wood += woodMine.Production + (decimal)plusPercentage;
                }
                else
                {
                    city.Wood += woodMine.Production;
                }

                this.cityRepository.SaveChangesAsync().GetAwaiter();
                this.woodMineReposistory.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
