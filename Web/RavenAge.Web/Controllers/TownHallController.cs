namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.HouseService;
    using RavenAge.Services.Data.TownhallService;
    using RavenAge.Web.ViewModels.TownHall;

    [Route("api/[controller]")]
    [ApiController]
    public class TownHallController : BaseController
    {
        private readonly ICityService cityService;
        private readonly ITownHallService townHallService;

        public TownHallController(
            ICityService cityService,
            ITownHallService townHallService)
        {
            this.cityService = cityService;
            this.townHallService = townHallService;
        }

        public async Task<TownHallUpgradeViewModel> LevelUp()
        {
            var userId = this.GetUserId();

            var result = await this.townHallService.TownHallLevelUp(userId);

            return result;
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
