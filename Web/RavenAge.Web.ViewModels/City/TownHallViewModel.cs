namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class TownHallViewModel : BaseBuildingModel, IMapFrom<TownHall>
    {
        public int ArmyLimit { get; set; }

        public decimal SilverPrice { get; set; }

        public decimal WoodPrice { get; set; }

        public decimal StonePrice { get; set; }
    }
}
