namespace RavenAge.Web.ViewModels.Barracks
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Text;

    public class HireSoldiersInputModel
    {
        public string Type { get; set; }

        [Required]
        [Range(0, 1000)]
        public int ArcharQuantity { get; set; }

        [Required]
        [Range(0, 1000)]
        public int InfantryQuantity { get; set; }

        [Required]
        [Range(0, 1000)]
        public int CavalryQuantity { get; set; }

        [Required]
        [Range(0, 1000)]
        public int ArtilleryQuantity { get; set; }
    }
}
