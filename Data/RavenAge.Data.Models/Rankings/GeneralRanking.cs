namespace RavenAge.Data.Models.Rankings
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class GeneralRanking : BaseModel<int>
    {
        public string UserName { get; set; }

        public int Points { get; set; }
    }
}
