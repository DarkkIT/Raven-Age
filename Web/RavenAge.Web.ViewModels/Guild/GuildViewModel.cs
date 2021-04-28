namespace RavenAge.Web.ViewModels.Guild
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using AutoMapper;
    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class GuildViewModel : IMapFrom<Guild>, IHaveCustomMappings
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string GuildMasterId { get; set; }

        public int MembersCount { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<Guild, GuildViewModel>().ForMember(s => s.MembersCount, t => t.MapFrom(x => x.Members.Count));
        }
    }
}
