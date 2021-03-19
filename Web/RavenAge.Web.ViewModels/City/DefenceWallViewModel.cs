namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class DefenceWallViewModel : BaseBuildingModel, IMapFrom<DefenceWall>
    {
        public int Defence { get; set; }

    }
}
