namespace RavenAge.Services.Data.HangfireService.Farm
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IFarmHangfireService
    {
        Task FarmFood();
    }
}
