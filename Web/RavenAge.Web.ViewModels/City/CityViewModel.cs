﻿namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;
    using RavenAge.Web.ViewModels.Barracks;

    public class CityViewModel : IMapFrom<City>
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int Workers { get; set; }

        public int Archers { get; set; }

        public int Infantry { get; set; }

        public int Cavalry { get; set; }

        public int Artillery { get; set; }

        public int Gold { get; set; } //// Premium

        public int Silver { get; set; }

        public int Stone { get; set; }

        public int Wood { get; set; }

        public DefenceWallViewModel DefenceWall { get; set; }

        public FarmViewModel Farm { get; set; }

        public HouseViewModel House { get; set; }

        public TownHallViewModel TownHall { get; set; }

        public WoodMineViewModel WoodMine { get; set; }

        public StoneMineViewMode StoneMine { get; set; }

        public BarracksViewModel Barracks { get; set; }

        public HireSoldiersInputModel HireSoldiersInputModel { get; set; }
    }
}
