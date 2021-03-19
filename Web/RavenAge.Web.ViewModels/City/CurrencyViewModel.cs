namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class CurrencyViewModel : IMapFrom<City>
    {
        public int Gold { get; set; } //// Premium

        public int Silver { get; set; }

        public int Stone { get; set; }

        public int Wood { get; set; }
    }
}
