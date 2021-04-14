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
    using RavenAge.Web.ViewModels.DefenceWall;

    [Route("api/[controller]")]
    [ApiController]
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

            public async Task<DefenceWallUpgradeViewModel> LevelUp()
            {
                var userId = this.GetUserId();

                var upgradeData = await this.defenceWallService.DefenceWallLevelUp(userId);

                return upgradeData;
            }

            internal string GetUserId()
            {
                return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
            }
    }
}
