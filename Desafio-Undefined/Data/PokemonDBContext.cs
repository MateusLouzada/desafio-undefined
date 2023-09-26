using Desafio_Undefined.Data.Map;
using Desafio_Undefined.Models;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Undefined.Data
{
    public class PokemonDBContext : DbContext
    {
        public PokemonDBContext(DbContextOptions<PokemonDBContext> options)
            : base(options)
        {
        }

        public DbSet<PokemonModel> Pokemons { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PokemonMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
