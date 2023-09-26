using Desafio_Undefined.Models;

namespace Desafio_Undefined.Repositories.Interfaces
{
    public interface IPokemonRepositorie
    {
        Task<List<PokemonModel>> GetAllPokemons();
        Task<PokemonModel> GetPokemonById(int id);
        Task<PokemonModel> InsertPokemon(PokemonModel pokemon);
        Task<PokemonModel> UpdatePokemon(PokemonModel pokemon, int id);
        Task<bool> DeletePokemon(int id);
    }
}
