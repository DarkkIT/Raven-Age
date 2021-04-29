namespace RavenAge.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.Data.GuildService;

    public class GuildController : Controller
    {
        private readonly IGuildService guildService;

        public GuildController(IGuildService guildService)
        {
            this.guildService = guildService;
        }

        public IActionResult Index()
        {

            var model = this.guildService.GetGuilds();

            return this.View(model);
        }

        public IActionResult Join()
        {
            return this.RedirectToAction("Index");
        }

        public IActionResult Leave()
        {
            return this.RedirectToAction("Index");
        }

        public IActionResult Create()
        {
            return this.RedirectToAction("Index");
        }
    }
}
