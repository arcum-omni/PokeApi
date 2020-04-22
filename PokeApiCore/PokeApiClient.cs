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
        /// <returns></returns>
        public async Task<string> GetPokemonByName(string name)
        {
            try
            {
                string url = $"https://pokeapi.co/api/v2/pokemon/{name}";
                HttpResponseMessage response = await client.GetAsync(url);
                response.EnsureSuccessStatusCode();
                string responseBody = await response.Content.ReadAsStringAsync();
                return responseBody;
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                throw ex;
            }
        }

        public void GetPokemonById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
