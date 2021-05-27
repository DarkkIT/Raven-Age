namespace RavenAge.Services.Data.ArenaBattleService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Web.ViewModels.Arena;

    public class ArenaBattleService : IArenaBattleService
    {
        public async Task<BattleResultViewModel> Attack(string attackerId, int defenderId)
        {
            var model = new BattleResultViewModel { ArenaPoints = 15 };

            return model;
        }
    }
}
