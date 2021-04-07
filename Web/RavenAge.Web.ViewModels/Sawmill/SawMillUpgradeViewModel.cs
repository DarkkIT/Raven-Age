namespace RavenAge.Web.ViewModels.Sawmill
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class SawMillUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int CurrentProduction { get; set; }

        public int NextLevelProduction { get; set; }

        public decimal SilverUpgradeCost { get; set; }

        public decimal WoodUpgradeCost { get; set; }

        public decimal StoneUpgradeCost { get; set; }

        public decimal SilverAvailable { get; set; }

        public decimal StoneAvailable { get; set; }

        public decimal WoodAvailable { get; set; }
    }
}
