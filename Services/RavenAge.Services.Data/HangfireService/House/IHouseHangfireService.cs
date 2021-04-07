namespace RavenAge.Services.Data.HangfireService.House
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IHouseHangfireService
    {
        Task FarmWorkers();
    }
}
