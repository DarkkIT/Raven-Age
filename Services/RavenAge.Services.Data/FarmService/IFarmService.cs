namespace RavenAge.Services.Data.FarmService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Farm;

    public interface IFarmService
    {
        Task<FarmUpgradeViewModel> FarmLevelUp(string userId);
    }
}
