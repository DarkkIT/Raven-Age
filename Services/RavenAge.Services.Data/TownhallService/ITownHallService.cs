namespace RavenAge.Services.Data.TownhallService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.TownHall;

    public interface ITownHallService
    {
        Task<TownHallUpgradeViewModel> TownHallLevelUp(string userId);
    }
}
