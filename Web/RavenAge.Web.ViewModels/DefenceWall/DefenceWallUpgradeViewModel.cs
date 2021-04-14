namespace RavenAge.Web.ViewModels.DefenceWall
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DefenceWallUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int Level { get; set; }

        public int CurrentProduction { get; set; }

        public int NextLevelProduction { get; set; }

        public decimal SilverUpgradeCost { get; set; }

        public decimal WoodUpgradeCost { get; set; }

        public decimal StoneUpgradeCost { get; set; }

        public decimal SilverAvailable { get; set; }

        public decimal StoneAvailable { get; set; }

        public decimal WoodAvailable { get; set; }

        public int DefencePoints { get; set; }

        public string Description { get; set; }
    }
}
