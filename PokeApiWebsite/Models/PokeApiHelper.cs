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
    }
}
