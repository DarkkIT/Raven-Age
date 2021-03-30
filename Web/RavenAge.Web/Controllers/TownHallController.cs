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

    public class TownHallController : Controller
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

        public async Task<IActionResult> LevelUp()
        {
            var userId = this.GetUserId();
            var model = this.cityService.GetCity(userId);

            await this.townHallService.TownHallLevelUp(userId);

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
