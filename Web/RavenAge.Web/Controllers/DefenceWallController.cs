namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.DefenceWall;

    public class DefenceWallController : Controller
    {
            private readonly ICityService cityService;
            private readonly IDefenceWallService defenceWallService;

            public DefenceWallController(
                ICityService cityService,
                IDefenceWallService defenceWallService)
            {
                this.cityService = cityService;
                this.defenceWallService = defenceWallService;
            }

            public async Task<IActionResult> LevelUp()
            {
                var userId = this.GetUserId();

                await this.defenceWallService.DefenceWallLevelUp(userId);

                return this.Redirect("/city/index");
            }

            internal string GetUserId()
            {
                return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
    }
}
