namespace RavenAge.Web.ViewModels.City
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models.Models;
    using RavenAge.Services.Mapping;

    public class MarketPlaceViewModel : BaseBuildingModel, IMapFrom<Marketplace>
    {
        public int Commission { get; set; }

    }
}
