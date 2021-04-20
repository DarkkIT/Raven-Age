namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class Guild: BaseDeletableModel<int>
    {
        public Guild()
        {
            this.Members = new HashSet<ApplicationUser>();

            this.JoinRequest = new HashSet<ApplicationUser>();

            this.GuildChat = new HashSet<Message>();
        }

        public string Name { get; set; }

        public string GuildMasterId { get; set; }

        public ApplicationUser GuildMaster { get; set; }

        public ICollection<ApplicationUser> Members { get; set; }

        public ICollection<Message> GuildChat { get; set; }

        public ICollection<ApplicationUser> JoinRequest { get; set; }
    }
}
