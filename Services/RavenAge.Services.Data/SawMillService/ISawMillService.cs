namespace RavenAge.Services.Data.SawMillService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Sawmill;

    public interface ISawMillService
    {
        Task<SawMillUpgradeViewModel> SawMillLevelUp(string userId);
    }
}
