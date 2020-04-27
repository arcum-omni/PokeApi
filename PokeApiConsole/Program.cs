using PokeApiCore;
using System;
using System.Reflection;
using System.Threading.Tasks;

namespace PokeApiConsole
{
    class Program
    {
        static async Task Main(string[] args)
        {
            PokeApiClient client = new PokeApiClient();
            Pokemon result = await client.GetPokemonByName("bulbasaur");
            Console.WriteLine($"Pokemon ID: {result.id} " +
                              $"\n  Name: {result.name} " +
                              $"\n  Weight: {result.weight}lbs" +
                              $"\n  Height: {result.height}in");

            Console.ReadKey();
        }
    }
}