using PokeApiCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokeApiWebsite.Models
{
    public static class PokeApiHelper
    {
        /// <summary>
        /// Get Pokemon by ID,
        /// moves will be sorted alphabetically.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<Pokemon> GetByID(int id)
        {
            PokeApiClient myClient = new PokeApiClient();
            Pokemon result = await myClient.GetPokemonById(id);

            // sorts moves by name, alphabetically
            result.moves.OrderBy(m => m.move.name);

            return result;
        }

        public static PokedexEntryViewModel GetPokedexEntryFromPokemon(Pokemon p)
        {
            var entry = new PokedexEntryViewModel()
            {
                Id = p.Id,
                Name = p.Name,
                Height = p.Height.ToString(),
                Weight = p.Weight.ToString(),
                PokeDexImageUrl = p.Sprites.FrontDefault,

                // Method syntax using lambda expressions, query syntax below
                MoveList = p.moves.OrderBy(m => m.move.name)
                                  .Select(m => m.move.name)
                                  .ToArray()
                //MoveList = (from m in p.moves
                //            orderby m.move.name
                //            select m.move.name).ToArray()
            };

            // Display Pokemon name in title case, ie Bulbasaur
            // First char to upper name => Name
            entry.Name = entry.Name.First().ToString().ToUpper() + entry.Name.Substring(1);
            return entry;
        }
    }
}
