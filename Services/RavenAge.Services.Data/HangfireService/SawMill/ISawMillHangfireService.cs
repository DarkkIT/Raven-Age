namespace RavenAge.Services.Data.HangfireService.SawMill
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface ISawMillHangfireService
    {
        Task FarmSaw();
    }
}
