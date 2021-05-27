namespace RavenAge.Services.Data.ArenaBattleService
{
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Arena;

    public interface IArenaBattleService
    {
        Task<BattleResultViewModel> Attack(string attackerId, int defenderId);
    }
}
