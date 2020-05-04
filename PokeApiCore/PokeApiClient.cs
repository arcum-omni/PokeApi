using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace PokeApiCore
{
    /// <summary>
    /// Client class to consume PokeApi:
    /// https://pokeapi.co/
    /// </summary>
    public class PokeApiClient
    {
        // Manage NuGet Packages, system.net.http (185M downloads)
        // Joe did in lecture, but I already had the using, and my project built
        static readonly HttpClient client;

        static PokeApiClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("https://pokeapi.co/api/v2/"); // End with forward slash!

            client.DefaultRequestHeaders.Add("User-Agent", "Travis' PokeAPI");
        }

        /// <summary>
        /// Retrieve Pokemon by name
        /// </summary>
        /// <exception cref="HttpRequestException"></exception>
        /// <param name="name"></param>
        /// <exception cref="ArgumentException">Thrown when Pokemon is not found</exception>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonByName(string name)
        {
            name = name.ToLower(); // Pokemon API requires lowercase name
            return await GetPokemonByNameOrID(name);
        }

        /// <summary>
        /// Retrieve Pokemon by their Pokedex ID number
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<Pokemon> GetPokemonById(int id)
        {
            return await GetPokemonByNameOrID(id.ToString());
        }

        private static async Task<Pokemon> GetPokemonByNameOrID(string name)
        {
            string url = $"pokemon/{name}";
            HttpResponseMessage response = await client.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                string responseBody = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<Pokemon>(responseBody);
            }
            else if (response.StatusCode == HttpStatusCode.NotFound)
            {
                throw new ArgumentException($"{name} Does Not Exist");
            }
            else
            {
                throw new HttpRequestException();
            }
        }
    }
}
