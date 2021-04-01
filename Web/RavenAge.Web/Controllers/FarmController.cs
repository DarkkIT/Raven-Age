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
    using RavenAge.Web.ViewModels.Farm;

    [Route("api/[controller]")]
    [ApiController]
    public class FarmController : BaseController
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

        public async Task<FarmUpgradeViewModel> LevelUp()
        {
            var userId = this.GetUserId();
            var data = await this.farmService.FarmLevelUp(userId);

            return data;
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
