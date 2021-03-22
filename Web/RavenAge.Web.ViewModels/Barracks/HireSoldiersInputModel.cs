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
        public int Quantity { get; set; }
    }
}
