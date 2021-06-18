namespace RavenAge.Services.Data.HangfireService.TaxesArmy
{
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;

    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;

    public class TaxArmy
    {
        private readonly IDeletableEntityRepository<City> cityRepository;
        private readonly IRepository<UserCity> userCityRepository;

        public TaxArmy(
            IDeletableEntityRepository<City> cityRepository,
            IRepository<UserCity> userCityRepository)
        {
            this.cityRepository = cityRepository;
            this.userCityRepository = userCityRepository;
        }

        public async Task GetTaxesFromArmy()
        {
            var userCities = this.userCityRepository.All();

            ////foreach (var userCity in userCities)
            ////{
            ////    var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == userCity.CityId);

            ////    // Tax army Food
            ////    var archersTaxFood = city.ArchersArmy.Count * GlobalConstants.FoodTaxForArmy;
            ////    var infantryTaxFood = city.InfantryArmy.Count * GlobalConstants.FoodTaxForArmy;
            ////    var cavalryTaxFood = city.CavalryArmy.Count * GlobalConstants.FoodTaxForArmy;
            ////    var catapulTaxFood = city.ArtilleryArmy.Count * GlobalConstants.FoodTaxForArmy;

            ////    // Tax army silver
            ////    var archersTaxSilver = city.ArchersArmy.Count * GlobalConstants.SilverTaxForArmy;
            ////    var infantryTaxSilver = city.InfantryArmy.Count * GlobalConstants.SilverTaxForArmy;
            ////    var cavalryTaxSilver = city.CavalryArmy.Count * GlobalConstants.SilverTaxForArmy;
            ////    var catapulTaxSilver = city.ArtilleryArmy.Count * GlobalConstants.SilverTaxForArmy;

            ////    // Tax workers
            ////    var workersFoodCost = city.Workers * GlobalConstants.FoodTaxForWorkers;

            ////    var foodCost = archersTaxFood + infantryTaxFood + cavalryTaxFood + catapulTaxFood + workersFoodCost;
            ////    var silverCost = archersTaxSilver + infantryTaxSilver + cavalryTaxSilver + catapulTaxSilver;

            ////    if (city.Food - foodCost < 0)
            ////    {
            ////        city.Food = 0;
            ////    }
            ////    else
            ////    {
            ////        city.Food -= foodCost;
            ////    }

            ////    if (city.Silver - silverCost < 0)
            ////    {
            ////        city.Silver = 0;
            ////    }
            ////    else
            ////    {
            ////        city.Silver -= silverCost;
            ////    }

            ////    this.cityRepository.SaveChangesAsync().GetAwaiter();
            ////}

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
