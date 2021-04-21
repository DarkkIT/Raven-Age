using RavenAge.Data.Common.Repositories;
using RavenAge.Data.Models.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace RavenAge.Services.Data.RuneService
{
    public class RuneService : IRuneService
    {
        private readonly IDeletableEntityRepository<Rune> runeRepo;

        public RuneService(IDeletableEntityRepository<Rune> runeRepo)
        {
            this.runeRepo = runeRepo;
        }

        public async Task AddRuneAsync(Rune rune)
        {
           await this.runeRepo.AddAsync(rune);
           await this.runeRepo.SaveChangesAsync();
        }
    }
}
