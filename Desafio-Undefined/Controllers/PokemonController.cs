using Desafio_Undefined.Models;
using Desafio_Undefined.Repositories.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Desafio_Undefined.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : ControllerBase
    {
        private readonly IPokemonRepositorie _pokemonRepositorie;

        public PokemonController(IPokemonRepositorie pokemonRepositorie)
        {
            _pokemonRepositorie = pokemonRepositorie;
        }

        [HttpGet]
        public async Task< ActionResult<List<PokemonModel>>> GetPokemons()
        {
            List<PokemonModel> pokemons = await _pokemonRepositorie.GetAllPokemons();
            return Ok(pokemons);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PokemonModel>> GetPokemonId(int id)
        {
            PokemonModel pokemon = await _pokemonRepositorie.GetPokemonById(id);
            return Ok(pokemon);
        }

        [HttpPost]
        public async Task<ActionResult<PokemonModel>> InsertPokemonReq([FromBody] PokemonModel pokemonModel)
        {
            PokemonModel pokemon = await _pokemonRepositorie.InsertPokemon(pokemonModel);

            return Ok(pokemon);
        }

        [HttpPut]
        public async Task<ActionResult<PokemonModel>> UpdatePokemonReq([FromBody] PokemonModel pokemonModel, int id)
        {
            pokemonModel.Id = id;
            PokemonModel pokemon = await _pokemonRepositorie.UpdatePokemon(pokemonModel, id);

            return Ok(pokemon);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<PokemonModel>> DeletePo(int id)
        {
            bool removed = await _pokemonRepositorie.DeletePokemon(id);

            return Ok(removed);
        }
    }
}
