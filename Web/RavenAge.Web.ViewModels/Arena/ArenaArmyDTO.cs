namespace RavenAge.Web.ViewModels.Arena
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class ArenaArmyDTO : IMapFrom<City>, IHaveCustomMappings
    {
        public int ArenaPoints { get; set; }

        public int ArmyTotalCount => this.ArchersCount + this.InfantryCount + this.CavalryCount + this.ArtilleryCount;

        //// Archers
        public int ArchersCount { get; set; }

        public int SingleArcherAttack { get; set; }

        public int SingleArcherHealth { get; set; }

        public int SingleArcherDefence { get; set; }

        public int TotalArcherHealth => (this.SingleArcherHealth + this.SingleArcherDefence) * this.ArchersCount;

        public int TotalArcherAttack => this.ArchersCount * this.SingleArcherAttack;

        //// Infantry
        public int InfantryCount { get; set; }

        public int SingleInfantryAttack { get; set; }

        public int SingleInfantryDefence { get; set; }

        public int SingleInfantryHealth { get; set; }

        public int TotalInfantryHealth => (this.SingleInfantryHealth + this.SingleInfantryDefence) * this.InfantryCount;

        public int TotalInfantryAttack => this.InfantryCount * this.SingleInfantryAttack;


        //// Cavalery
        public int CavalryCount { get; set; }

        public int SingleCavalryAttack { get; set; }

        public int SingleCavalryDefence { get; set; }

        public int SingleCavalryHealth { get; set; }

        public int TotalCavalryHealth => (this.SingleCavalryDefence + this.SingleCavalryHealth) * this.CavalryCount;

        public int TotalCavalryAttack => this.CavalryCount * this.SingleCavalryAttack;

        //// Artilery
        public int ArtilleryCount { get; set; }

        public int SingleArtileryAttack { get; set; }

        public int SingleArtileryDefence { get; set; }

        public int SingleArtilleryHealth { get; set; }

        public int TotalArtilleryHealth => (this.SingleArtilleryHealth + this.SingleArtileryDefence) * this.ArtilleryCount;

        public int TotalArtilleryAttack => this.ArtilleryCount * this.SingleArtileryAttack;

        //// Maping

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, ArenaArmyDTO>()
                .ForMember(t => t.SingleArcherAttack, opt => opt.MapFrom(s => s.Archers.Attack + s.Archers.Bonus))
                .ForMember(t => t.SingleArcherHealth, opt => opt.MapFrom(s => s.Archers.Health + s.Archers.HealthBonus + s.Archers.Defence + s.Archers.DefenceBonus))
                .ForMember(t => t.SingleInfantryAttack, opt => opt.MapFrom(s => s.Infantry.Attack + s.Infantry.Bonus))
                .ForMember(t => t.SingleInfantryHealth, opt => opt.MapFrom(s => s.Infantry.Health + s.Infantry.HealthBonus + s.Infantry.Defence + s.Infantry.DefenceBonus))
                .ForMember(t => t.SingleCavalryAttack, opt => opt.MapFrom(s => s.Cavalry.Attack + s.Cavalry.Bonus))
                .ForMember(t => t.SingleCavalryHealth, opt => opt.MapFrom(s => s.Cavalry.Health + s.Cavalry.HealthBonus + s.Cavalry.Defence + s.Cavalry.DefenceBonus))
                .ForMember(t => t.SingleArtileryAttack, opt => opt.MapFrom(s => s.Artillery.Attack + s.Artillery.Bonus))
                .ForMember(t => t.SingleArtilleryHealth, opt => opt.MapFrom(s => s.Artillery.Health + s.Artillery.HealthBonus + s.Artillery.Defence + s.Artillery.DefenceBonus))
                .ForMember(t => t.ArchersCount, opt => opt.MapFrom(s => s.Archers.Count))
                .ForMember(t => t.InfantryCount, opt => opt.MapFrom(s => s.Infantry.Count))
                .ForMember(t => t.CavalryCount, opt => opt.MapFrom(s => s.Cavalry.Count))
                .ForMember(t => t.ArtilleryCount, opt => opt.MapFrom(s => s.Artillery.Count))
                .ForMember(t => t.ArmyTotalCount, opt => opt.MapFrom(s => s.Artillery.Count + s.Infantry.Count + s.Cavalry.Count + s.Artillery.Count));
        }
    }
}
