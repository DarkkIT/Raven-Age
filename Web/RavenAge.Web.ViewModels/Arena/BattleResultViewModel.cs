namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class BattleResultViewModel : IMapFrom<BattleResult>

    {
        public string Attacker { get; set; }

        public string Defender { get; set; }

        //// Winner

        public string Winner { get; set; }

        public int ArenaPoints { get; set; }

        //// Attacker Army Loss

        public int AttackerArchersLost { get; set; }

        public int AttackerInfantrysLost { get; set; }

        public int AttackerCavalryLost { get; set; }

        public int AttackerArtilleryLost { get; set; }

        //// Defender Army Loss

        public int DefenderArchersLost { get; set; }

        public int DefenderInfantryLost { get; set; }

        public int DefenderCavalryLost { get; set; }

        public int DefenderArtilleryLost { get; set; }

        public int DefenseWallPointsLost { get; set; }

        public List<string> BattleReport { get; set; }

    }
}
