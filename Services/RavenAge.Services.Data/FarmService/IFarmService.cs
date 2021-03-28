namespace RavenAge.Services.Data.FarmService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFarmService
    {
        Task FarmLevelUp(string userId);
    }
}
