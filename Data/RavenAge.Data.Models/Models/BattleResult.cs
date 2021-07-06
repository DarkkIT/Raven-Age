namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class BattleResult : BaseModel<int>
    {
        public string Attacker { get; set; }

        public string Defender { get; set; }

        //// Winner

        public string Winner { get; set; }

        public int StoneProfit { get; set; }

        public int WoodProfit { get; set; }

        public int GoldProfit { get; set; }

        public string BattleType { get; set; }

        //// Attacker Armys

        public int AttackerArchers { get; set; }

        public int AttackerInfantry { get; set; }

        public int AttackerCavalry { get; set; }

        public int AttackerArtillery { get; set; }

        //// Attacker Army Loss

        public int AttackerArchersLost { get; set; }

        public int AttackerInfantryLost { get; set; }

        public int AttackerCavalryLost { get; set; }

        public int AttackerArtilleryLost { get; set; }

        //// Defender Armys

        public int DefenderArchers { get; set; }

        public int DefenderInfantry { get; set; }

        public int DefenderCavalry { get; set; }

        public int DefenderArtillery { get; set; }

        public int DefenseWallPoints { get; set; }

        //// Defender Army Loss

        public int DefenderArchersLost { get; set; }

        public int DefenderInfantryLost { get; set; }

        public int DefenderCavalryLost { get; set; }

        public int DefenderArtilleryLost { get; set; }

        public int DefenseWallPointsLost { get; set; }
    }
}
