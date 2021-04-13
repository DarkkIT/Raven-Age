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
    using RavenAge.Web.ViewModels.House;

    [Route("api/[controller]")]
    [ApiController]
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

        public async Task<HouseUpgradeViewModel> LevelUp()
        {
            var userId = this.GetUserId();
            var data = await this.houseService.HouseLevelUp(userId);

            return data;
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
