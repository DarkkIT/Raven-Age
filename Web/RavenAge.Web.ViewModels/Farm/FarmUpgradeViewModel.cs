namespace RavenAge.Web.ViewModels.Farm
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class FarmUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int CurrentProduction { get; set; }

        public int NextLevelProduction { get; set; }

        public decimal SilverUpgradeCost { get; set; }

        public decimal WoodUpgradeCost { get; set; }

        public decimal StoneUpgradeCost { get; set; }
    }
}
