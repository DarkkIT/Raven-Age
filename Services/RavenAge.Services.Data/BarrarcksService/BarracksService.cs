namespace RavenAge.Services.Data.BarrarcksService
{
    using System;
    using System.Collections.Generic;
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

        public Task AddSoldiersAsync(HireSoldiersInputModel input, string userId)
        {
            throw new NotImplementedException();
        }

        public BarracksViewModel GetBarracks(string userId)
        {
            throw new NotImplementedException();
        }
    }
}
