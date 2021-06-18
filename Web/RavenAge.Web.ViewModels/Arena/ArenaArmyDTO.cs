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
        public int ArenaPints { get; set; }

        public int ArmyTotalCount { get; set; }

        //// Archers
        public int ArchersCount { get; set; }

        public int FullArcherAttack { get; set; }

        public int FullArcherHealth { get; set; }

        public int FullArcherDefence { get; set; }

        //// Infantry
        public int InfantryCount { get; set; }

        public int FullInfantriAttack { get; set; }

        public int FullInfantryDefence { get; set; }

        public int FullInfantryHealth { get; set; }

        //// Cavalery
        public int CavaleryCount { get; set; }

        public int FullCavaleryAttack { get; set; }

        public int FullCavaleryDefence { get; set; }

        public int FullCavaleryHealth { get; set; }

        //// Artilery
        public int ArtiletyCount { get; set; }

        public int FullArtileryAttack { get; set; }

        public int FullArtileryDefence { get; set; }

        public int FullArtileryHealth { get; set; }

        //// Maping

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, ArenaArmyDTO>()
                .ForMember(t => t.FullArcherAttack, opt => opt.MapFrom(s => s.ArchersArmy.Attack + s.ArchersArmy.Bonus))
                .ForMember(t => t.FullArcherHealth, opt => opt.MapFrom(s => s.ArchersArmy.Health + s.ArchersArmy.HealthBonus + s.ArchersArmy.Defence + s.ArchersArmy.DefenceBonus))
                .ForMember(t => t.FullInfantriAttack, opt => opt.MapFrom(s => s.InfantryArmy.Attack + s.InfantryArmy.Bonus))
                .ForMember(t => t.FullInfantryHealth, opt => opt.MapFrom(s => s.InfantryArmy.Health + s.InfantryArmy.HealthBonus + s.InfantryArmy.Defence + s.InfantryArmy.DefenceBonus))
                .ForMember(t => t.FullCavaleryAttack, opt => opt.MapFrom(s => s.CavalryArmy.Attack + s.CavalryArmy.Bonus))
                .ForMember(t => t.FullCavaleryHealth, opt => opt.MapFrom(s => s.CavalryArmy.Health + s.CavalryArmy.HealthBonus + s.CavalryArmy.Defence + s.CavalryArmy.DefenceBonus))
                .ForMember(t => t.FullArtileryAttack, opt => opt.MapFrom(s => s.ArtilleryArmy.Attack + s.ArtilleryArmy.Bonus))
                .ForMember(t => t.FullArtileryHealth, opt => opt.MapFrom(s => s.ArtilleryArmy.Health + s.ArtilleryArmy.HealthBonus + s.ArtilleryArmy.Defence + s.ArtilleryArmy.DefenceBonus))
                .ForMember(t => t.ArchersCount, opt => opt.MapFrom(s => s.ArchersArmy.Count))
                .ForMember(t => t.InfantryCount, opt => opt.MapFrom(s => s.InfantryArmy.Count))
                .ForMember(t => t.CavaleryCount, opt => opt.MapFrom(s => s.CavalryArmy.Count))
                .ForMember(t => t.ArtiletyCount, opt => opt.MapFrom(s => s.ArtilleryArmy.Count))
                .ForMember(t => t.ArmyTotalCount, opt => opt.MapFrom(s => s.ArtilleryArmy.Count + s.InfantryArmy.Count + s.CavalryArmy.Count + s.ArtilleryArmy.Count));
        }
    }
}
