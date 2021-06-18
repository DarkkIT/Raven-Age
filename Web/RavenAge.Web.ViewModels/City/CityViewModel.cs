namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Barracks;

    public class CityViewModel : IMapFrom<City>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; } //// Race

        public string Avatar { get; set; }

        public int Premium { get; set; }

        public int Workers { get; set; }

        public int Archers { get; set; }

        public int Infantry { get; set; }

        public int Cavalry { get; set; }

        public int Artillery { get; set; }

        public decimal Gold { get; set; } //// Premium

        public decimal Silver { get; set; }

        public decimal Stone { get; set; }

        public decimal Wood { get; set; }

        public decimal Food { get; set; }

        public DefenceWallViewModel DefenceWall { get; set; }

        public FarmViewModel Farm { get; set; }

        public HouseViewModel House { get; set; }

        public TownHallViewModel TownHall { get; set; }

        public WoodMineViewModel WoodMine { get; set; }

        public StoneMineViewMode StoneMine { get; set; }

        public BarracksViewModel Barracks { get; set; }

        public ArmyViewModel Army { get; set; }

        public RuneViewModel Runes { get; set; }

        public HireSoldiersInputModel HireSoldiersInputModel { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, CityViewModel>()
                .ForMember(t => t.Archers, x => x.MapFrom(s => s.ArchersArmy.Count))
                .ForMember(t => t.Cavalry, x => x.MapFrom(s => s.CavalryArmy.Count))
                .ForMember(t => t.Artillery, x => x.MapFrom(s => s.ArtilleryArmy.Count))
                .ForMember(t => t.Infantry, x => x.MapFrom(s => s.InfantryArmy.Count));
        }
    }
}
