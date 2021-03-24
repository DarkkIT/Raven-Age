namespace RavenAge.Services.Data.HouseService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHouseService
    {
        Task HouseLevelUp(string userId);
    }
}
