using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
            int desiredID = 1;

            Pokemon p = await PokeApiHelper.GetByID(desiredID);

            // TODO: Refactor property names
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

            return View(entry);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}