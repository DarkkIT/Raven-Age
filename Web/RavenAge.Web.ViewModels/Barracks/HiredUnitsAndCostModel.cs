namespace RavenAge.Web.ViewModels.Barracks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class HiredUnitsAndCostModel
    {
        public int UnitQuantity { get; set; }

        public string UnitType { get; set; }

        public int WoodSpent { get; set; }

        public int SilverSpent { get; set; }
    }
}
