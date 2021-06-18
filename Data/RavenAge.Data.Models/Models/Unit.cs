namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public abstract class Unit : BaseDeletableModel<int>
    {
        public int Attack { get; set; }

        public int Bonus { get; set; }

        public int Defence { get; set; }

        public int DefenceBonus { get; set; }

        public int Health { get; set; }

        public int Count { get; set; }

        public int HealthBonus { get; set; }

        public bool AttackRune { get; set; }

        public bool DefenseRune { get; set; }

        public bool HealthRune { get; set; }

    }
}