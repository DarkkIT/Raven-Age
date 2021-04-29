namespace RavenAge.Services.Data.GuildService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Guild;

    public interface IGuildService
    {

        List<GuildViewModel> GetGuilds();

        Task Create(int userId);

        Task Join(int userId, int guildId);

        Task Leave(int userId, int guildId);

        Task ApproveJoinGuild(int guildId);
    }
}
