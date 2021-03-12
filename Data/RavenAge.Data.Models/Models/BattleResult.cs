namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class BattleResult : BaseModel<int>
    {
        public string Atacker { get; set; }

        public string Defender { get; set; }

        //// Winner

        public string Winner { get; set; }

        public int StoneProfit { get; set; }

        public int WoodProfit { get; set; }

        public int GoldProfit { get; set; }

        //// Attacker Armys

        public int AttackerArchers { get; set; }

        public int AtackerInfantrys { get; set; }

        public int AtackerCavalry { get; set; }

        public int AtackerArtillery { get; set; }

        //// Attacker Army Loss

        public int AttackerArchersLoss { get; set; }

        public int AtackerInfantrysLoss { get; set; }

        public int AtackerCavalryLoss { get; set; }

        public int AtackerArtilleryLoss { get; set; }

        //// Defender Armys

        public int DefenderArchers { get; set; }

        public int DefenderInfantrys { get; set; }

        public int DefenderCavalry { get; set; }

        public int DefenderArtillery { get; set; }

        public int DefenseWallPoints { get; set; }

        //// Defender Army Loss

        public int DefenderArchersLoss { get; set; }

        public int DefenderInfantrysLoss { get; set; }

        public int DefenderCavalryLoss { get; set; }

        public int DefenderArtilleryLoss { get; set; }

        public int DefenseWallPointsLoss { get; set; }
    }
}
