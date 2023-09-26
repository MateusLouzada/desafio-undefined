using Desafio_Undefined.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desafio_Undefined.Data.Map
{
    public class PokemonMap : IEntityTypeConfiguration<PokemonModel>
    {
        public void Configure(EntityTypeBuilder<PokemonModel> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.TypePokemon).IsRequired();
            builder.Property(x => x.Description).IsRequired();
        }
    }
}
