namespace RavenAge.Data.Models.Models
{
    using System.Collections.Generic;

    using RavenAge.Data.Common.Models;

    public class Rune : BaseDeletableModel<int>
    {
        //// Archers Runes

        public bool ArcherAttackRune { get; set; }

        public bool ArcherDefenseRune { get; set; }

        public bool ArcherHealthRune { get; set; }

        //// Infantrys Runes

        public bool InfantryAttackRune { get; set; }

        public bool InfantryDefenseRune { get; set; }

        public bool InfantryHealthRune { get; set; }

        //// Cavalry Runes

        public bool CavalryAttackRune { get; set; }

        public bool CavalryDefenseRune { get; set; }

        public bool CavalryHealthRune { get; set; }

        //// Artillery Runes

        public bool ArtilleryAttackRune { get; set; }

        public bool ArtilleryDefenseRune { get; set; }

        public bool ArtilleryHealthRune { get; set; }

        //// Resources Runes

        public bool StoneRune { get; set; }

        public bool WoodRune { get; set; }

        public bool FoodRunes { get; set; }

        public bool SilverRune { get; set; }
    }
}
