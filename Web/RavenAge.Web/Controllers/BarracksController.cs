namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Services.Data.BarracksService;
    using RavenAge.Web.ViewModels.Barracks;

    [Route("api/[controller]")]
    [ApiController]
    public class BarracksController : BaseController
    {
        private readonly ICityService cityService;
        private readonly IBarracksService barrackService;

        public BarracksController(ICityService cityService, IBarracksService barrackService)
        {
            this.cityService = cityService;
            this.barrackService = barrackService;
        }

        [HttpPost]
        public async Task<IActionResult> Hire(HireSoldiersInputModel input)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.barrackService.AddSoldiersAsync(input, userId);

            //var model = this.cityService.GetCity(userId);

            return /*this.View(model);*/ null;
        }

    }
}
