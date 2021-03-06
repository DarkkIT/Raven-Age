namespace RavenAge.Services.CityService.Data
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using RavenAge.Data.Models.Models;
    using RavenAge.Web.ViewModels.Barracks;
    using RavenAge.Web.ViewModels.City;


    public interface ICityService
    {
        Task CreateStartUpCity(string userId, string name, string avatar, int runeId);

        BarracksViewModel GetBarracks(string userId);

        FarmViewModel GetFarm(string userId);

        HouseViewModel GetHouse(string userId);

        TownHallViewModel GetTownHall(string userId);

        WoodMineViewModel GetWoodMine(string userId);

        StoneMineViewMode GetStoneMine(string userId);

        DefenceWallViewModel GetDefenceWall(string userId);

        Task<MarketPlaceViewModel> GetMarketPlace(string userId);

        ArmyViewModel GetArmy(string userId);

        RuneViewModel GetRune(string userId);

        CityViewModel GetCity(string userId);

    }
}
