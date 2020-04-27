using Newtonsoft.Json;
using System;
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
        static readonly HttpClient client = new HttpClient();

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
            string url = $"https://pokeapi.co/api/v2/pokemon/{name}";
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

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
