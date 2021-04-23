namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class Message : BaseDeletableModel<int>
    {
        public string Content { get; set; }

        public DateTime SendTime { get; set; }

        public string PlayerId { get; set; }

        public ApplicationUser Player { get; set; }

        public int GuildId { get; set; }

        public Guild Guild { get; set; }
    }
}
