namespace RavenAge.Web.ViewModels.TownHall
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TownHallUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int ArmyLimit { get; set; }

        public decimal SilverUpgradeCost { get; set; }

        public decimal WoodUpgradeCost { get; set; }

        public decimal StoneUpgradeCost { get; set; }

        public decimal SilverAvailable { get; set; }

        public decimal StoneAvailable { get; set; }

        public decimal WoodAvailable { get; set; }

    }
}
