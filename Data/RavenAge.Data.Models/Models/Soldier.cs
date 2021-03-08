namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class Soldier : BaseModel<int>
    {
        public int Attack { get; set; }

        public int Defence { get; set; }

        public int Healt { get; set; }

        public int Quantity { get; set; }

        public string Type { get; set; }
    }
}
