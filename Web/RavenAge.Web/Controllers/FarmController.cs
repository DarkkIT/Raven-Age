namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.FarmService;

    public class FarmController : Controller
    {
        private readonly ICityService cityService;
        private readonly IFarmService farmService;

        public FarmController(
            ICityService cityService,
            IFarmService farmService)
        {
            this.cityService = cityService;
            this.farmService = farmService;
        }

        public async Task<IActionResult> LevelUp()
        {
            var userId = this.GetUserId();
            var model = this.cityService.GetCity(userId);

            await this.farmService.FarmLevelUp(userId);

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
