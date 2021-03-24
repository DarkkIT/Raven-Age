namespace RavenAge.Services.Data.BarraksService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Barracks;
    using RavenAge.Web.ViewModels.City;

    public class BarracksService : IBarracksService
    {
        private readonly IDeletableEntityRepository<Barracks> barracksRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;

        public BarracksService(
                           IDeletableEntityRepository<Barracks> barracksRepo,
                           IRepository<UserCity> userCityRepo,
                           IDeletableEntityRepository<City> cityRepo)
        {
            this.barracksRepo = barracksRepo;
            this.userCityRepo = userCityRepo;
            this.cityRepo = cityRepo;
        }

        public async Task AddSoldiersAsync(HireSoldiersInputModel input, string userId)
        {
            var city = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).City;

            var curentSilver = city.Silver;
            var curentWood = city.Wood;

            var silverNeeded = (input.ArcharQuantity * 50) + (input.InfantryQuantity * 100)
                + (input.CavalryQuantity * 100) + (input.ArtilleryQuantity * 25);
            var woodNeeded = (input.ArcharQuantity * 50) + (input.InfantryQuantity * 15)
                + (input.CavalryQuantity * 15) + (input.ArtilleryQuantity * 100);

            if (silverNeeded <= curentSilver && woodNeeded <= curentWood)
            {
                city.Archers += input.ArcharQuantity;
                city.Infantry += input.InfantryQuantity;
                city.Cavalry += input.CavalryQuantity;
                city.Artillery += input.ArtilleryQuantity;

                city.Silver -= silverNeeded;
                city.Wood -= woodNeeded;
            }

            await this.cityRepo.SaveChangesAsync();
        }

        public BarracksViewModel GetBarracks(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
