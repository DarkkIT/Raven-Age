namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class ArmyViewModel : IMapFrom<Army>
    {
        //// Archers

        public int ArcherAttack { get; set; }

        public int ArcherAttackBonus { get; set; }

        public int ArcherDefence { get; set; }

        public int ArcherDefenceBonus { get; set; }

        public int ArcherHealth { get; set; }

        public int ArcherHealtBonus { get; set; }

        //// Infantry

        public int InfantryAttack { get; set; }

        public int InfantryAttackBonus { get; set; }

        public int InfantryDefence { get; set; }

        public int InfantryDefenceBonus { get; set; }

        public int InfantryHealth { get; set; }

        public int InfantryHealthBonus { get; set; }

        //// Cavalry

        public int CavalryAttack { get; set; }

        public int CavalryAttackBonus { get; set; }

        public int CavalryDefence { get; set; }

        public int CavalryDefenceBonus { get; set; }

        public int CavalryHealth { get; set; }

        public int CavalryHealthBonus { get; set; }

        //// Artillery

        public int ArtilleryAttack { get; set; }

        public int ArtilleryAttackBonus { get; set; }

        public int ArtilleryDefence { get; set; }

        public int ArtilleryDefenceBonus { get; set; }

        public int ArtilleryHealth { get; set; }

        public int ArtilleryHealthBonus { get; set; }
    }
}
