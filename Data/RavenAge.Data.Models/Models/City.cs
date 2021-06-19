namespace RavenAge.Data.Models.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
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

        public int InfantryId { get; set; }

        [ForeignKey("InfantryId")]

        public Infantry Infantry { get; set; }

        public int CavalryId { get; set; }

        [ForeignKey("CavalryId")]

        public Cavalry Cavalry { get; set; }

        public int ArtilleryId { get; set; }

        [ForeignKey("ArtilleryId")]

        public Artillery Artillery { get; set; }

        public int ArchersId { get; set; }

        [ForeignKey("ArchersId")]
        public Archers Archers { get; set; }

        public int RuneId { get; set; }

        public Rune Rune { get; set; }

        public virtual ICollection<UserCity> UserCities { get; set; }
    }
}
