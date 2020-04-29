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

                Console.WriteLine($"Pokemon ID: {result.id} " +
                                  $"\n  Name: {result.name} " +
                                  $"\n  Weight: {result.weight}lbs" +
                                  $"\n  Height: {result.height}in");
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