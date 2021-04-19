namespace RavenAge.Services.Data.HangfireService
{
    using System.Threading.Tasks;

    public interface IStoneMineHangfireJobService
    {
        Task FarmStone();
    }
}