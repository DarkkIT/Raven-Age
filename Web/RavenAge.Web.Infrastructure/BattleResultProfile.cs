namespace RavenAge.Web.Infrastructure
{
    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Arena;

    public class BattleResultProfile : Profile
    {
        public BattleResultProfile()
        {
            this.CreateMap<BattleResult, BattleResultViewModel>().ReverseMap();
        }
    }
}
