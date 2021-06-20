namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BattleResultViewModel
    {
        public string Atacker { get; set; }

        public string Defender { get; set; }

        //// Winner

        public string Winner { get; set; }

        public int ArenaPoints { get; set; }

        //// Attacker Army Loss

        public int AttackerArchersLoss { get; set; }

        public int AtackerInfantrysLoss { get; set; }

        public int AtackerCavalryLoss { get; set; }

        public int AtackerArtilleryLoss { get; set; }

        //// Defender Army Loss

        public int DefenderArchersLoss { get; set; }

        public int DefenderInfantrysLoss { get; set; }

        public int DefenderCavalryLoss { get; set; }

        public int DefenderArtilleryLoss { get; set; }

        public int DefenseWallPointsLoss { get; set; }
    }
}
