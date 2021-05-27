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

        public ArenaListViewModel GetArenaList(string userId)
        {
            var fullList = this.cityRepo.All().To<ArenaUserViewModel>().OrderByDescending(x => x.ArenaPoints).ToList();

            var cityId = this.userCityRepo.All().FirstOrDefault(x => x.UserId == userId).CityId;

            var curentId = fullList.FindIndex(a => a.Id == cityId);

            var arenaList = new List<ArenaUserViewModel>();

            var min = curentId - 5 < 0 ? 0 : curentId - 5;
            var max = curentId + 5 > fullList.Count - 1 ? fullList.Count - 1 : curentId + 5;

            for (int i = min; i < max; i++)
            {
                arenaList.Add(fullList[i]);
            }

            var attacker = fullList.FirstOrDefault(x => x.Id == cityId);

            var fullArenaList = new ArenaListViewModel { ArenaList = arenaList, Attacker = attacker };

            return fullArenaList;
        }
    }
}
