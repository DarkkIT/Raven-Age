using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RavenAge.Web.Areas.Identity.Pages.Account
{
    public class Register3 : PageModel
    {
        public async Task<IActionResult> OnGetAsync(string type = null, string avatar = null)
        {
            this.ViewData["type"] = type;
            this.ViewData["avatar"] = avatar;
            return this.Page();
        }
    }
}
