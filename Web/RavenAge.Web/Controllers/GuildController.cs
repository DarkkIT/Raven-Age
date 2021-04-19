namespace RavenAge.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;

    public class GuildController : Controller
    {
        public IActionResult Index()
        {
            return this.View();
        }
    }
}
