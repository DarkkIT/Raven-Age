namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Common.Models;

    public class City : BaseDeletableModel<int>
    {
        public string Type { get; set; } //// Race

        public string Avatar { get; set; }

        public int Premium { get; set; }

        public int ArenaPoints { get; set; }

        //// City Name

        public string Name { get; set; }

        //// City Population

        public int Workers { get; set; }

        //// City Resources

        public decimal Gold { get; set; } //// Premium

        public decimal Silver { get; set; }

        public decimal Stone { get; set; }

        public decimal Wood { get; set; }

        public decimal Food { get; set; }

        //// City Buildings

        public int TownHallId { get; set; }

        public TownHall TownHall { get; set; }

        public int BarracksId { get; set; }

        public Barracks Barracks { get; set; }

        public int FarmId { get; set; }

        public Farm Farm { get; set; }

        public int MarketplaceId { get; set; }

        public Marketplace Marketplace { get; set; }

        public int StoneMineId { get; set; }

        public StoneMine StoneMine { get; set; }

        public int WoodMineId { get; set; }

        public WoodMine WoodMine { get; set; }

        public int HouseId { get; set; }

        public House House { get; set; }

        public int DefenceWallId { get; set; }

        public DefenceWall DefenceWall { get; set; }

        public int InfantryArmyId { get; set; }

        public Infantry InfantryArmy { get; set; }

        public int CavalryArmyId { get; set; }

        public Cavalry CavalryArmy { get; set; }

        public int ArtilleryArmyId { get; set; }

        public Artillery ArtilleryArmy { get; set; }

        public int ArchersArmyId { get; set; }

        public Archers ArchersArmy { get; set; }

        public int RuneId { get; set; }

        public Rune Rune { get; set; }

        public virtual ICollection<UserCity> UserCities { get; set; }
    }
}
