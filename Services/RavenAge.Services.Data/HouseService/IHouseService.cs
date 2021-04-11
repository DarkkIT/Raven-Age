namespace RavenAge.Services.Data.HouseService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.House;

    public interface IHouseService
    {
        Task<HouseUpgradeViewModel> HouseLevelUp(string userId);
    }
}
