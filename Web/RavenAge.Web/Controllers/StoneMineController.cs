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
    using RavenAge.Web.ViewModels.StoneQuarry;

    [ApiController]
    [Route("api/[controller]")]
    public class StoneMineController : BaseController
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

        public async Task<StoneQuarryUpgradeViewModel> LevelUp()
        {
            var userId = this.GetUserId();
            var data = await this.stoneMineService.StoneMineLevelUp(userId);

            return data;
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
