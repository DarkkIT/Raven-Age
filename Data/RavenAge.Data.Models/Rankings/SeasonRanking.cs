namespace RavenAge.Data.Models.Rankings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class SeasonRanking : BaseModel<int>
    {
        public string UserName { get; set; }

        public int Points { get; set; }
    }
}
