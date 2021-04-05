namespace RavenAge.Services.Data.StoneMineService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    public interface IStoneMineService
    {
        Task StoneMineLevelUp(string userId);
    }
}
