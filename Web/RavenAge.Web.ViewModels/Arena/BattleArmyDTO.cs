namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class BattleArmyDTO
    {
        public BattleArmyDTO()
        {
            this.Army = new List<BattleUnitDTO>();
        }

        public int ArenaPoints { get; set; }

        public int TotalArmyCount => this.Army.Select(x => x.Count).Sum();

        public List<BattleUnitDTO> Army { get; set; }
    }
}
