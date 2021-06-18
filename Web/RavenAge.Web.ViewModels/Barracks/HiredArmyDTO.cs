namespace RavenAge.Web.ViewModels.Barracks
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class HiredArmyDTO : IMapFrom<City>, IMapTo<City>, IHaveCustomMappings
    {
        public int ArchersArmyCount { get; set; }

        public int InfantryArmyCount { get; set; }

        public int CavalryArmyCount { get; set; }

        public int ArtilleryArmyCount { get; set; }

        public int Silver { get; set; }

        public int Wood { get; set; }

        public int Stone { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            //configuration.CreateMap<City, HiredArmyDTO>()
            //    .ForMember(t => t.ArchersCount)

        }
    }
}
