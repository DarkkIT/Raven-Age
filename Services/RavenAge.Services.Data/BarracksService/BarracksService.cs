namespace RavenAge.Services.Data.BarracksService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using RavenAge.Common;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Barracks;
    using RavenAge.Web.ViewModels.City;

    public class BarracksService : IBarracksService
    {
        private readonly IDeletableEntityRepository<Barracks> barracksRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IDeletableEntityRepository<Archers> archersRepo;
        private readonly IDeletableEntityRepository<Cavalry> cavalryRepo;
        private readonly IDeletableEntityRepository<Artillery> artilleryRepo;
        private readonly IDeletableEntityRepository<Infantry> infantryRepo;

        public BarracksService(
                           IDeletableEntityRepository<Barracks> barracksRepo,
                           IRepository<UserCity> userCityRepo,
                           IDeletableEntityRepository<City> cityRepo,
                           IDeletableEntityRepository<Archers> archersRepo,
                           IDeletableEntityRepository<Cavalry> cavalryRepo,
                           IDeletableEntityRepository<Artillery> artilleryRepo,
                           IDeletableEntityRepository<Infantry> infantryRepo)
        {
            this.barracksRepo = barracksRepo;
            this.userCityRepo = userCityRepo;
            this.cityRepo = cityRepo;
            this.archersRepo = archersRepo;
            this.cavalryRepo = cavalryRepo;
            this.artilleryRepo = artilleryRepo;
            this.infantryRepo = infantryRepo;
        }

        public async Task<HiredUnitsAndCostModel> AddSoldiersAsync(HireSoldiersInputModel input)
        {
            var city = this.cityRepo.All().FirstOrDefault(x => x.Id == input.CityId);
            var archers = this.archersRepo.All().FirstOrDefault(x => x.CityId == input.CityId);
            var cavalry = this.cavalryRepo.All().FirstOrDefault(x => x.CityId == input.CityId);
            var artillery = this.artilleryRepo.All().FirstOrDefault(x => x.CityId == input.CityId);
            var infantry = this.infantryRepo.All().FirstOrDefault(x => x.CityId == input.CityId);

            var currentSilver = city.Silver;
            var currentWood = city.Wood;

            var silverNeeded = (input.ArcherQuantity * GlobalConstants.ArcherSilverCost) +
                               (input.InfantryQuantity * GlobalConstants.InfantrySilverCost) +
                               (input.CavalryQuantity * GlobalConstants.CavalrySilverCost) +
                               (input.ArtilleryQuantity * GlobalConstants.ArtillerySilverCost);

            var woodNeeded = (input.ArcherQuantity * GlobalConstants.ArcherWoodCost) +
                             (input.InfantryQuantity * GlobalConstants.InfantryWoodCost) +
                             (input.CavalryQuantity * GlobalConstants.CavalryWoodCost) +
                             (input.ArtilleryQuantity * GlobalConstants.ArcherWoodCost);

            var viewData = new HiredUnitsAndCostModel();

            if (silverNeeded <= currentSilver && woodNeeded <= currentWood)
            {

                artillery.Count += input.ArtilleryQuantity;
                infantry.Count += input.InfantryQuantity;
                cavalry.Count += input.CavalryQuantity;
                archers.Count += input.ArcherQuantity;

                city.Silver -= silverNeeded;
                city.Wood -= woodNeeded;
                await this.cityRepo.SaveChangesAsync();
                await this.artilleryRepo.SaveChangesAsync();
                await this.cavalryRepo.SaveChangesAsync();
                await this.archersRepo.SaveChangesAsync();

                var unitType = string.Empty;

                viewData.SilverAvailable = city.Silver;
                viewData.StoneAvailable = city.Stone;
                viewData.WoodAvailable = city.Wood;

                if (input.ArcherQuantity > 0)
                {
                    viewData.UnitType = "Archers";
                    viewData.UnitQuantity = archers.Count;
                }
                else if (input.InfantryQuantity > 0)
                {
                    viewData.UnitType = "Infantry";
                    viewData.UnitQuantity = infantry.Count;
                }
                else if (input.CavalryQuantity > 0)
                {
                    viewData.UnitType = "Cavalry";
                    viewData.UnitQuantity = cavalry.Count;
                }
                else if (input.ArtilleryQuantity > 0)
                {
                    viewData.UnitType = "Artillery";
                    viewData.UnitQuantity = artillery.Count;
                }

                return viewData;
            }

            return null;
        }

        public BarracksViewModel GetBarracks(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
