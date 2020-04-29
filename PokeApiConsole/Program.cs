using PokeApiCore;
using System;
using System.Net.Http;
using System.Reflection;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PokeApiClient client = new PokeApiClient();
            try
            {
                //Pokemon result = await client.GetPokemonByName("Bulbasaur");
                Pokemon result = await client.GetPokemonById(1);

                Console.WriteLine($"Pokemon ID: {result.Id} " +
                                  $"\n  Name: {result.Name} " +
                                  $"\n  Weight: {result.Weight}lbs" +
                                  $"\n  Height: {result.Height}in");
            }
            catch (ArgumentException)
            {
                Console.WriteLine("That Pokemon does not exist");
            }
            catch (HttpRequestException)
            {
                Console.WriteLine("Please try again later.");
            }
            

            Console.ReadKey();
        }
    }
}