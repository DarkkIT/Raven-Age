namespace RavenAge.Services.Data.BarraksService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Barracks;
    using RavenAge.Web.ViewModels.City;

    public interface IBarracksService
    {
        BarracksViewModel GetBarracks(string userId);

        Task AddSoldiersAsync (HireSoldiersInputModel input, string userId);

    }
}
