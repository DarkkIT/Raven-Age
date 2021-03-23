namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.CityService.Data;

    public class HouseController : Controller
    {
        private readonly ICityService cityService;

        public HouseController(ICityService cityService)
        {
            this.cityService = cityService;
        }

        public IActionResult LevelUp()
        {
            var model = this.cityService.GetCity(this.GetUserId());

            return this.Redirect("~/City/Index");
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
