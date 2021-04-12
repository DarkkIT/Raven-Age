namespace RavenAge.Web.ViewModels.DefenceWall
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class DefenceWallUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int Level { get; set; }

        public decimal SilverPrice { get; set; }

        public decimal WoodPrice { get; set; }

        public decimal StonePrice { get; set; }

        public int Defence { get; set; }

        public string Description { get; set; }
    }
}
