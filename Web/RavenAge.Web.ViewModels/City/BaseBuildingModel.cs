namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public abstract class BaseBuildingModel
    {
        public int Level { get; set; }

        public decimal Price { get; set; }

        public string Description { get; set; }
    }
}
