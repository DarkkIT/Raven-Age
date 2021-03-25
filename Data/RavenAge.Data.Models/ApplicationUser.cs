// ReSharper disable VirtualMemberCallInConstructor
namespace RavenAge.Data.Models
{
    using System;
    using System.Collections.Generic;

    using Microsoft.AspNetCore.Identity;
    using RavenAge.Data.Common.Models;
    using RavenAge.Data.Models.Models;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.AttackRune = false;
            this.DefenseRune = false;
            this.HealthRune = false;

        }

        //// User stats set by registration

        public int Premium { get; set; }

        public string Name { get; set; }

        public string Type { get; set; } //// Race

        public string Avatar { get; set; }

        public bool AttackRune { get; set; }

        public bool DefenseRune { get; set; }

        public bool HealthRune { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }

        public virtual ICollection<UserCity> UserCities { get; set; }
    }
}
