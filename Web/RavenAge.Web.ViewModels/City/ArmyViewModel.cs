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

        public int ArcherAtack { get; set; }

        public int ArcherAtackBonus { get; set; }

        public int ArcherDefence { get; set; }

        public int ArcherDefenceBonus { get; set; }

        public int ArcherHealt { get; set; }

        public int ArcherHealtBonus { get; set; }

        //// Infantry

        public int InfantryAtack { get; set; }

        public int InfantryAtackBonus { get; set; }

        public int InfantryDefence { get; set; }

        public int InfantryDefenceBonus { get; set; }

        public int InfantryHealt { get; set; }

        public int InfantryHealtBonus { get; set; }

        //// Cavalry

        public int CavalryAtack { get; set; }

        public int CavalryAtackBonus { get; set; }

        public int CavalryDefence { get; set; }

        public int CavalryDefenceBonus { get; set; }

        public int CavalryHealt { get; set; }

        public int CavalryHealtBonus { get; set; }

        //// Artillery

        public int ArtilleryAtack { get; set; }

        public int ArtilleryAtackBonus { get; set; }

        public int ArtilleryDefence { get; set; }

        public int ArtilleryDefenceBonus { get; set; }

        public int ArtilleryHealt { get; set; }

        public int ArtilleryHealtBonus { get; set; }
    }
}
