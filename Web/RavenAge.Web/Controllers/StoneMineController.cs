namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.StoneMineService;

    public class StoneMineController : Controller
    {
        private readonly ICityService cityService;
        private readonly IStoneMineService stoneMineService;

        public StoneMineController(
            ICityService cityService,
            IStoneMineService stoneMineService)
        {
            this.cityService = cityService;
            this.stoneMineService = stoneMineService;
        }

        public async Task<IActionResult> LevelUp()
        {
            var userId = this.GetUserId();
            var model = this.cityService.GetCity(userId);

            await this.stoneMineService.StoneMineLevelUp(userId);

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
