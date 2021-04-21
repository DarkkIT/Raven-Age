namespace RavenAge.Services.Data.ArenaService
{
    using RavenAge.Data.Common.Repositories;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Arena;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class ArenaService : IArenaService
    {
        private readonly IDeletableEntityRepository<City> cityRepo;
        private readonly IRepository<UserCity> userCityRepo;

        public ArenaService(
            IDeletableEntityRepository<City> cityRepo,
            IRepository<UserCity> userCityRepo)
        {
            this.cityRepo = cityRepo;
            this.userCityRepo = userCityRepo;
        }

        public List<ArenaUserViewModel> GetArenaList(string userId)
        {
            var fullArenaList = this.cityRepo.All().To<ArenaUserViewModel>().ToList();

            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var curentId = fullArenaList.FindIndex(a => a.Id == cityId);

            var arenaList = new List<ArenaUserViewModel>();

            var min = curentId - 5 < 0 ? 0 : curentId - 5;
            var max = curentId + 5 > fullArenaList.Count - 1 ? fullArenaList.Count - 1 : curentId + 5;

            for (int i = curentId - min; i < curentId + max; i++)
            {
                arenaList.Add(fullArenaList[i]);
            }

            return arenaList;
        }
    }
}
