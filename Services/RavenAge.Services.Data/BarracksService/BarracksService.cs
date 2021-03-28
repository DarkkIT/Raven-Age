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

        public async Task<HiredUnitsAndCostModel> AddSoldiersAsync(HireSoldiersInputModel input, string userId)
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

            var hiredUnits = new HiredUnitsAndCostModel();

            if (silverNeeded <= curentSilver && woodNeeded <= curentWood)
            {
                city.Archers += input.ArcharQuantity;
                city.Infantry += input.InfantryQuantity;
                city.Cavalry += input.CavalryQuantity;
                city.Artillery += input.ArtilleryQuantity;

                city.Silver -= silverNeeded;
                city.Wood -= woodNeeded;
                await this.cityRepo.SaveChangesAsync();

                var unitType = string.Empty;
                int unitQuantity = 0;

                if (input.ArcharQuantity > 0)
                {
                    unitType = "Archers";
                    unitQuantity = input.ArcharQuantity;
                }
                else if (input.InfantryQuantity > 0)
                {
                    unitType = "Infantry";
                    unitQuantity = input.InfantryQuantity;
                }
                else if (input.CavalryQuantity > 0)
                {
                    unitType = "Vavalry";
                    unitQuantity = input.CavalryQuantity;
                }
                else if (input.ArtilleryQuantity > 0)
                {
                    unitType = "Artillery";
                    unitQuantity = input.ArtilleryQuantity;
                }

                return new HiredUnitsAndCostModel { UnitQuantity = unitQuantity, UnitType = unitType, WoodSpent = woodNeeded, SilverSpent = silverNeeded };
            }

            return null;
        }

        public BarracksViewModel GetBarracks(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
