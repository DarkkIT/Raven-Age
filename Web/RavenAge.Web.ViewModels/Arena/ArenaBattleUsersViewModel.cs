namespace RavenAge.Web.ViewModels.Arena
{
    using System.Collections.Generic;

    using RavenAge.Web.ViewModels.City;

    public class ArenaBattleUsersViewModel
    {
        public IEnumerable<CityViewModel> ArenaUsers { get; set; }
    }
}
