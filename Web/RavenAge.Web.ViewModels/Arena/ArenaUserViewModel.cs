namespace RavenAge.Web.ViewModels.Arena
{
    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.City;

    public class ArenaUserViewModel : IMapFrom<City>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int ArenaPoints { get; set; }

        public string Avatar { get; set; }

        public string Name { get; set; }

        public int Archers { get; set; }

        public int Infantry { get; set; }

        public int Cavalry { get; set; }

        public int Artillery { get; set; }

        public ArmyViewModel Army { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<City, ArenaUserViewModel>()
                .ForMember(t => t.Archers, opt => opt.MapFrom(s => s.Archers.Count))
                .ForMember(t => t.Infantry, opt => opt.MapFrom(s => s.Infantry.Count))
                .ForMember(t => t.Cavalry, opt => opt.MapFrom(s => s.Cavalry.Count))
                .ForMember(t => t.Artillery, opt => opt.MapFrom(s => s.Artillery.Count));
        }
    }
}
