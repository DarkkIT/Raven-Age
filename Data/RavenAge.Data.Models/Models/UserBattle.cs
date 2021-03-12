namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class UserBattle : BaseModel<int>
    {
        public int UserId { get; set; }

        public ApplicationUser User { get; set; }

        public int BattleResultId { get; set; }

        public BattleResult BattleResult { get; set; }
    }
}
