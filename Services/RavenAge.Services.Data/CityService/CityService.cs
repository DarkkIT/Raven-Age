namespace RavenAge.Services.CityService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Barracks;
    using RavenAge.Web.ViewModels.City;

    public class CityService : ICityService
    {
        private readonly IDeletableEntityRepository<Barracks> barracksRepo;
        private readonly IDeletableEntityRepository<House> houseRepo;
        private readonly IDeletableEntityRepository<WoodMine> woodMineRepo;
        private readonly IDeletableEntityRepository<StoneMine> stoneMineRepo;
        private readonly IDeletableEntityRepository<Marketplace> marketplaceRepo;
        private readonly IDeletableEntityRepository<DefenceWall> defenceWallRepo;
        private readonly IRepository<UserCity> userCityRepo;
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IDeletableEntityRepository<TownHall> townHallRepo;

        public CityService(
                           IDeletableEntityRepository<Barracks> barracksRepo,
                           IDeletableEntityRepository<House> houseRepo,
                           IDeletableEntityRepository<TownHall> townHallRepo,
                           IDeletableEntityRepository<WoodMine> woodMineRepo,
                           IDeletableEntityRepository<StoneMine> stoneMineRepo,
                           IDeletableEntityRepository<Marketplace> marketplaceRepo,
                           IDeletableEntityRepository<DefenceWall> defenceWallRepo,
                           IDeletableEntityRepository<Farm> farmRepo,
                           IRepository<UserCity> userCityRepo,
                           IDeletableEntityRepository<City> cityRepo)
        {
            this.barracksRepo = barracksRepo;
            this.houseRepo = houseRepo;
            this.woodMineRepo = woodMineRepo;
            this.stoneMineRepo = stoneMineRepo;
            this.marketplaceRepo = marketplaceRepo;
            this.defenceWallRepo = defenceWallRepo;
            this.userCityRepo = userCityRepo;
            this.cityRepo = cityRepo;
            this.townHallRepo = townHallRepo;
        }



        public async Task CreateStartUpCity(string userId)
        {
            var city = new City()
            {
                Barracks = new Barracks { Level = 1, Description = "This is barracks!" },
                DefenceWall = new DefenceWall { Level = 1, Description = "This is a defence wall!" },
                Farm = new Farm { Level = 1, Description = "This is a farm!" },
                House = new House { Level = 1, Description = "This is a house!" },
                Marketplace = new Marketplace { Level = 1, Description = "This is a marketplace!" },
                WoodMine = new WoodMine { Level = 1, Description = "This is a woodmine!" },
                StoneMine = new StoneMine { Level = 1, Description = "This is a stone mine!" },
                TownHall = new TownHall { Level = 1, Description = "This is a townhall!" },
                Infantry = 10,
                Silver = 1000,
                Stone = 100,
                Wood = 100,
            };

            var userCity = new UserCity() { UserId = userId, City = city };
            await this.userCityRepo.AddAsync(userCity);
            await this.userCityRepo.SaveChangesAsync();
        }

        public BarracksViewModel GetBarracks(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Barracks).To<BarracksViewModel>().FirstOrDefault();
        }

        public CityViewModel GetCity(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City).To<CityViewModel>().FirstOrDefault();
        }

        public DefenceWallViewModel GetDefenceWall(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.DefenceWall).To<DefenceWallViewModel>().FirstOrDefault();
        }

        public FarmViewModel GetFarm(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Farm).To<FarmViewModel>().FirstOrDefault();
        }

        public HouseViewModel GetHouse(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.House).To<HouseViewModel>().FirstOrDefault();
        }

        public MarketPlaceViewModel GetMarketPlace(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Marketplace).To<MarketPlaceViewModel>().FirstOrDefault();
        }

        public StoneMineViewMode GetStoneMine(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.StoneMine).To<StoneMineViewMode>().FirstOrDefault();
        }

        public TownHallViewModel GetTownHall(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.TownHall).To<TownHallViewModel>().FirstOrDefault();
        }

        public WoodMineViewModel GetWoodMine(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.WoodMine).To<WoodMineViewModel>().FirstOrDefault();
        }
    }
}
