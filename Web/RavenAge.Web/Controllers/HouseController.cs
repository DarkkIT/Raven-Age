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

    public class HouseController : Controller
    {
        private readonly ICityService cityService;
        private readonly IHouseService houseService;

        public HouseController(
            ICityService cityService,
            IHouseService houseService)
        {
            this.cityService = cityService;
            this.houseService = houseService;
        }

        public async Task<IActionResult> LevelUp()
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var model = this.cityService.GetCity(this.GetUserId());

            await this.houseService.HouseLevelUp(userId);

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
