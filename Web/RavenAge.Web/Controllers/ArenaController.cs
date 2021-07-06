namespace RavenAge.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNetCore.Mvc;
    using Newtonsoft.Json;
    using RavenAge.Services.Data.ArenaBattleService;
    using RavenAge.Services.Data.ArenaService;
    using RavenAge.Web.ViewModels.Arena;

    public class ArenaController : Controller
    {
        private readonly IArenaService arenaService;
        private readonly IArenaBattleService arenaBattleService;

        public ArenaController(IArenaService arenaService, IArenaBattleService arenaBattleService)
        {
            this.arenaService = arenaService;
            this.arenaBattleService = arenaBattleService;
        }

        public IActionResult Index()
        {
            var userId = this.GetUserId();
            var model = this.arenaService.GetArenaList(userId);
            return this.View(model);
        }

        public async Task<IActionResult> Attack(int id)
        {
            var attackerId = this.GetUserId();
            var defenderId = id;

            var viewModel = this.arenaService.GetArenaList(attackerId);

            viewModel.BattleResult = await this.arenaBattleService.Attack(attackerId, defenderId);

            return this.View("Index", viewModel);
        }

        internal string GetUserId()
        {
            return this.User.FindFirst(ClaimTypes.NameIdentifier).Value;
        }
    }
}
