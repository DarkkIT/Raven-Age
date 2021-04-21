namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.Data.ArenaService;
    using RavenAge.Web.ViewModels.Arena;

    public class ArenaController : Controller
    {
        private readonly IArenaService arenaService;

        public ArenaController(IArenaService arenaService)
        {
            this.arenaService = arenaService;
        }

        public IActionResult Index()
        {
            var userId = this.GetUserId();

            var list = this.arenaService.GetArenaList(userId);

            var viewModel = new ArenaListViewModel { ArenaList = list };

            return this.View(viewModel);
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
