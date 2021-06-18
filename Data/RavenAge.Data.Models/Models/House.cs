﻿namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class House : BaseDeletableModel<int>
    {
        public int Level { get; set; }

        public decimal SilverPrice { get; set; }

        public decimal WoodPrice { get; set; }

        public decimal StonePrice { get; set; }

        public int Production { get; set; }

        public int WorkerLimit { get; set; }

        public string Description { get; set; }

        public bool SilverRune { get; set; }
    }
}
