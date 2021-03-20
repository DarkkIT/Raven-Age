namespace RavenAge.Web.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using RavenAge.Data.Models;
    using RavenAge.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Name { get; set; }

        public bool AttackRune { get; set; }

        public bool DefenseRune { get; set; }

        public bool HealthRune { get; set; }

        public string Avatar { get; set; }

    }
}
