namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class Farm : BaseDeletableModel<int>
    {
        public int Level { get; set; }

        public decimal Price { get; set; }

        public int FoodProduction { get; set; }

        public string Description { get; set; }
    }
}
