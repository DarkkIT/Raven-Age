namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;
    using RavenAge.Web.ViewModels.Barracks;

    public class CityController : Controller
    {
        private readonly ICityService cityService;

        public CityController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult Index()
        {
           var model = this.cityService.GetCity(this.GetUserId());

           return this.View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Index(HireSoldiersInputModel input)
        {
            var userId = this.GetUserId();

            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            await this.cityService.AddSoldiersAsync(input, userId);

            var model = this.cityService.GetCity(userId);

            return this.View(model);
        }

        public IActionResult BarracksStats()
        {
            var model = this.cityService.GetBarracks(this.GetUserId());
            return this.View(model);
        }

        public IActionResult TownhallStats()
        {
            var model = this.cityService.GetTownHall(this.GetUserId());
            return this.View(model);
        }

        public async Task<IActionResult> CreateCity()
        {
            await this.cityService.CreateStartUpCity(this.GetUserId());
            return this.RedirectToAction("Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
