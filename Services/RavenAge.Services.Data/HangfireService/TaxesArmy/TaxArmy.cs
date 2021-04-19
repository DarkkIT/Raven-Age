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

            foreach (var userCity in userCities)
            {
                var city = await this.cityRepository.All().FirstOrDefaultAsync(x => x.Id == userCity.CityId);

                // Tax army Food
                var archersTaxFood = city.Archers * GlobalConstants.FoodTaxForArmy;
                var infantryTaxFood = city.Infantry * GlobalConstants.FoodTaxForArmy;
                var cavalryTaxFood = city.Cavalry * GlobalConstants.FoodTaxForArmy;
                var catapulTaxFood = city.Artillery * GlobalConstants.FoodTaxForArmy;

                // Tax army silver
                var archersTaxSilver = city.Archers * GlobalConstants.SilverTaxForArmy;
                var infantryTaxSilver = city.Infantry * GlobalConstants.SilverTaxForArmy;
                var cavalryTaxSilver = city.Cavalry * GlobalConstants.SilverTaxForArmy;
                var catapulTaxSilver = city.Artillery * GlobalConstants.SilverTaxForArmy;

                // Tax workers
                var workersTax = city.Workers * GlobalConstants.FoodTaxForWorkers;

                // TODO: Need to validate if city food and silver go under the zero
                city.Food -= archersTaxFood + infantryTaxFood + cavalryTaxFood + catapulTaxFood;
                city.Silver -= archersTaxSilver + infantryTaxSilver + cavalryTaxSilver + catapulTaxSilver;
                city.Food -= workersTax;

                this.cityRepository.SaveChangesAsync().GetAwaiter();
            }

            await this.userCityRepository.SaveChangesAsync();
        }
    }
}
