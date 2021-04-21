namespace RavenAge.Services.Data.ArenaService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Arena;

    public interface IArenaService
    {
        List<ArenaUserViewModel> GetArenaList(string userId);
    }
}
