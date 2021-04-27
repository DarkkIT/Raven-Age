namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;

    public class BattleController : Controller
    {

        public IActionResult Attack()
        {
            return this.RedirectToAction("Index", "Arena");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
