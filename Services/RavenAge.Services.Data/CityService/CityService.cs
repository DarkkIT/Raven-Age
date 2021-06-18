namespace RavenAge.Services.CityService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    using Microsoft.EntityFrameworkCore;
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Services.UserService.Data;
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
        private readonly IUserService userService;
        private readonly IDeletableEntityRepository<Rune> runeRepo;

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
                           IDeletableEntityRepository<City> cityRepo,
                           IUserService userService,
                           IDeletableEntityRepository<Rune> runeRepo)
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
            this.userService = userService;
            this.runeRepo = runeRepo;
        }

        public async Task CreateStartUpCity(string userId, string name, string avatar, int runeId)
        {
            var city = new City()
            {
                Avatar = avatar,
                Name = name,
                Barracks = new Barracks { Level = 1, Description = "This is barracks!", SilverPrice = 12, StonePrice = 16, WoodPrice = 16, TrainingLimit = 100 },
                DefenceWall = new DefenceWall { Level = 1, Description = "This is a defence wall!", SilverPrice = 12, StonePrice = 24, WoodPrice = 8, Defence = 1000 },
                Farm = new Farm { Level = 1, Description = "This is a farm!", FoodProduction = 100, SilverPrice = 13, StonePrice = 8, WoodPrice = 12 },
                House = new House { Level = 1, Description = "This is a house!", WorkerLimit = 100, SilverPrice = 10, StonePrice = 15, WoodPrice = 15, Production = 4 },
                Marketplace = new Marketplace { Level = 1, Description = "This is a marketplace!", SilverPrice = 10, StonePrice = 15, WoodPrice = 15 },
                WoodMine = new WoodMine { Level = 1, Description = "This is a woodmine!", Production = 100, SilverPrice = 10, StonePrice = 12, WoodPrice = 13 },
                StoneMine = new StoneMine { Level = 1, Description = "This is a stone mine!", Production = 100, SilverPrice = 10, StonePrice = 35, WoodPrice = 12 },
                TownHall = new TownHall { Level = 1, Description = "This is a townhall!", SilverPrice = 11, StonePrice = 14, WoodPrice = 14, ArmyLimit = 250 },
                ArchersArmy = new Archers { Attack = 1000, Defence = 1000, Health = 1000, Count = 11 },
                InfantryArmy = new Infantry { Attack = 1000, Defence = 1000, Health = 1000, Count = 11 },
                CavalryArmy = new Cavalry { Attack = 1000, Defence = 1000, Health = 1000, Count = 11 },
                ArtilleryArmy = new Artillery { Attack = 1000, Defence = 1000, Health = 1000, Count = 11 },

                RuneId = runeId,

                Silver = 1000,
                Stone = 100,
                Wood = 100,
                Food = 200,
                Workers = 50,
                Gold = 10,
            };

            ////var user = await this.userService.GetUserById(userId);

            await this.cityRepo.AddAsync(city);

            await this.cityRepo.SaveChangesAsync();

            var userCity = new UserCity() { UserId = userId, CityId = city.Id };

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

        public async Task<MarketPlaceViewModel> GetMarketPlace(string userId)
        {
            return await this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Marketplace).To<MarketPlaceViewModel>().FirstOrDefaultAsync();
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

        public ArmyViewModel GetArmy(string userId)
        {
            return new ArmyViewModel();
            ////this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Army).To<ArmyViewModel>().FirstOrDefault();
        }

        public RuneViewModel GetRune(string userId)
        {
            return this.userCityRepo.AllAsNoTracking().Where(x => x.UserId == userId).Select(x => x.City.Rune).To<RuneViewModel>().FirstOrDefault();
        }
    }
}
