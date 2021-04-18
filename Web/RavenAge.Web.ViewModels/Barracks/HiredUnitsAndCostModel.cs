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

        public decimal SilverAvailable { get; set; }

        public decimal StoneAvailable { get; set; }

        public decimal WoodAvailable { get; set; }
    }
}
