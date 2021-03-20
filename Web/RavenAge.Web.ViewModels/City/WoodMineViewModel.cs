namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class WoodMineViewModel : BaseBuildingModel, IMapFrom<WoodMine>
    {
        public int Production { get; set; }

    }
}
