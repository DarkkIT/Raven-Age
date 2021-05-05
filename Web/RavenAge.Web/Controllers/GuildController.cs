namespace RavenAge.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using RavenAge.Services.Data.GuildService;
    using RavenAge.Web.ViewModels.Guild;
    using System.Security.Claims;
    using System.Threading.Tasks;

    public class GuildController : Controller
    {
        private readonly IGuildService guildService;

        public GuildController(IGuildService guildService)
        {
            this.guildService = guildService;
        }

        public IActionResult Index()
        {
            var model = new GuildListViewModel();
            model.Guilds = this.guildService.GetGuilds();

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

        [HttpPost]
        public async Task<IActionResult> Create(CreateGuildInputViewModel model)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier).Value;

            await this.guildService.Create(userId, model.Name);
            return this.RedirectToAction("Index");
        }
    }
}
