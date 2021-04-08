namespace RavenAge.Services.Data.StoneMineService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.StoneQuarry;

    public interface IStoneMineService
    {
        Task<StoneQuarryUpgradeViewModel> StoneMineLevelUp(string userId);
    }
}
