namespace RavenAge.Web.ViewModels.House
{
    using System;
    using System.Collections.Generic;
    using System.Text;

   public class HouseUpgradeViewModel
    {
        public bool IsUpgraded { get; set; }

        public int CurrentWorkersCount { get; set; }

        public int WorkerLimit { get; set; }

        public int Production { get; set; }

        public int IncomePerWorker { get; set; }

        public decimal SilverUpgradeCost { get; set; }

        public decimal WoodUpgradeCost { get; set; }

        public decimal StoneUpgradeCost { get; set; }

        public decimal SilverAvailable { get; set; }

        public decimal StoneAvailable { get; set; }

        public decimal WoodAvailable { get; set; }
    }
}
