namespace RavenAge.Web.ViewModels.Arena
{
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class ArenaUserViewModel : IMapFrom<City>
    {
        public int Id { get; set; }

        public int ArenaPoints { get; set; }

        public string Avatar { get; set; }

        public string Name { get; set; }

        public int Archers { get; set; }

        public int Infantry { get; set; }

        public int Cavalry { get; set; }

        public int Artillery { get; set; }

        public ArmyViewModel Armies { get; set; }
    }
}
