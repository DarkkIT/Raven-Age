namespace RavenAge.Services.Data.BarracksService
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
    using RavenAge.Common;

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
            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;
            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == cityId);

            var curentSilver = city.Silver;
            var curentWood = city.Wood;

            var silverNeeded = (input.ArcharQuantity * GlobalConstants.ArcherSilverCost) +
                               (input.InfantryQuantity * GlobalConstants.InfantrySilverCost) +
                               (input.CavalryQuantity * GlobalConstants.CavalrySilverCost) +
                               (input.ArtilleryQuantity * GlobalConstants.ArtillerySilverCost);

            var woodNeeded = (input.ArcharQuantity * GlobalConstants.ArcherWoodCost) +
                             (input.InfantryQuantity * GlobalConstants.InfantryWoodCost) +
                             (input.CavalryQuantity * GlobalConstants.CavalryWoodCost) +
                             (input.ArtilleryQuantity * GlobalConstants.ArcherWoodCost);

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
