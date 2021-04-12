namespace RavenAge.Services.Data.DefenceWall
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.DefenceWall;

    public interface IDefenceWallService
    {
        Task DefenceWallLevelUp(string userId);
    }
}
