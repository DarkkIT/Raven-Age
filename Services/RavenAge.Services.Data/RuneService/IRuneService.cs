namespace RavenAge.Services.Data.RuneService
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using RavenAge.Data.Models.Models;

    public interface IRuneService
    {
         Task AddRuneAsync(Rune rune);
    }
}
