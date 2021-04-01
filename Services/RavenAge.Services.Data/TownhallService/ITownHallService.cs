namespace RavenAge.Services.Data.TownhallService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ITownHallService
    {
        Task TownHallLevelUp(string userId);
    }
}
