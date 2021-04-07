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
    using RavenAge.Web.ViewModels.Sawmill;

    [Route("api/[controller]")]
    [ApiController]
    public class SawMillController : BaseController
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

        public async Task<SawMillUpgradeViewModel> LevelUp()
        {
            var userId = this.GetUserId();

            var data = await this.sawMillService.SawMillLevelUp(userId);

            return data;
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
