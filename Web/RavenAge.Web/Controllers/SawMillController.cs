namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.SawMillService;

    public class SawMillController : Controller
    {
        private readonly ICityService cityService;
        private readonly ISawMillService sawMillService;

        public SawMillController(
            ICityService cityService,
            ISawMillService sawMillService)
        {
            this.cityService = cityService;
            this.sawMillService = sawMillService;
        }

        public async Task<IActionResult> LevelUp()
        {
            var userId = this.GetUserId();
            var model = this.cityService.GetCity(userId);

            await this.sawMillService.SawMillLevelUp(userId);

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
