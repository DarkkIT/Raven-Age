namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class ArenaListViewModel
    {
        public IEnumerable<ArenaUserViewModel> ArenaList { get; set; }

        public ArenaUserViewModel Attacker { get; set; }

        public BattleResultViewModel BattleResult { get; set; }
    }
}
