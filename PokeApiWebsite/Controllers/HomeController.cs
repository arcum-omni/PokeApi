using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PokeApiCore;
using PokeApiWebsite.Models;

namespace PokeApiWebsite.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public async Task<IActionResult> Index()
        {
            PokeApiClient myClient = new PokeApiClient();
            Pokemon result = await myClient.GetPokemonById(1);

            // TODO: Add move list
            List<string> resultMoves = new List<string>();
            foreach (Move currMove in result.moves)
            {
                resultMoves.Add(currMove.move.name);
            }

            resultMoves.Sort();

            // TODO: Refactor property names
            var entry = new PokedexEntryViewModel()
            {
                Id = result.Id,
                Name = result.Name,
                Height = result.Height.ToString(),
                Weight = result.Weight.ToString(),
                PokeDexImageUrl = result.Sprites.FrontDefault,
                MoveList = resultMoves
            };

            // Display Pokemon name in title case, ie Bulbasaur
            // First char to upper name => Name
            entry.Name = entry.Name.First().ToString().ToUpper() + entry.Name.Substring(1);

            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}