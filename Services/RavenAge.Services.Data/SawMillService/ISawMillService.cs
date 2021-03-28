namespace RavenAge.Services.Data.SawMillService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISawMillService
    {
        Task SawMillLevelUp(string userId);
    }
}
