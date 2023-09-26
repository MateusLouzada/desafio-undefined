using Desafio_Undefined.Data;
using Desafio_Undefined.Models;
using Desafio_Undefined.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Desafio_Undefined.Repositories
{
    public class PokemonRepositorie : IPokemonRepositorie
    {
        private readonly PokemonDBContext _dbContext;
        public PokemonRepositorie(PokemonDBContext pokemonDBContext)
        {
            _dbContext = pokemonDBContext;
        }

        public async Task<bool> DeletePokemon(int id)
        {
            PokemonModel pokemonForId = await GetPokemonById(id);

            if (pokemonForId == null)
            {
                throw new Exception("Não existe esse pokemon");
            }

            _dbContext.Pokemons.Remove(pokemonForId);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<List<PokemonModel>> GetAllPokemons()
        {
            return await _dbContext.Pokemons.ToListAsync();
        }

        public async Task<PokemonModel> GetPokemonById(int id)
        {
            PokemonModel pokemonForId = await _dbContext.Pokemons.FirstAsync(p => p.Id == id);

            if (pokemonForId == null)
            {
                throw new Exception("Não existe esse pokemon");
            }

            return pokemonForId;
        }

        public async Task<PokemonModel> InsertPokemon(PokemonModel pokemon)
        {
            await _dbContext.Pokemons.AddAsync(pokemon);
            await _dbContext.SaveChangesAsync();

            return pokemon;
        }

        public async Task<PokemonModel> UpdatePokemon(PokemonModel pokemon, int id)
        {
            PokemonModel pokemonForId = await GetPokemonById(id);

            if (pokemonForId == null)
            {
                throw new Exception("Não existe esse pokemon");
            }

            pokemonForId.Name = pokemon.Name;
            pokemonForId.TypePokemon = pokemon.TypePokemon;
            pokemonForId.Description = pokemon.Description;

            _dbContext.Pokemons.Update(pokemonForId);
            await _dbContext.SaveChangesAsync();

            return pokemonForId;
        }
    }
}
