﻿namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class BarracksViewModel : BaseBuildingModel, IMapFrom<Barracks>
    {
        public int TrainingLimit { get; set; }

        public decimal SilverPrice { get; set; }

        public decimal WoodPrice { get; set; }

        public decimal StonePrice { get; set; }
    }
}
