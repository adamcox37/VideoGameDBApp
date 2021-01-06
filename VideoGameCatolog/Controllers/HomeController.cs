using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using VideoGameCatolog.Models;
using System.Data.SQLite;
using DataAccessLibrary;

namespace VideoGameCatolog.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConsoleDB()
        {
            return View();
        }

        public IActionResult AddGame() // Right clicked on method to Add View.  Add Razor View and make sure you are pulling from the correct Model
        {
            return View();
        }

        [HttpPost] // Set up to post data to DB
        [ValidateAntiForgeryToken] // Second level of security if JavaScript fails or is turned off
        public IActionResult AddGame(VideoGameModel videoGame)
        {
            if (ModelState.IsValid)
            {
                int recordsCreated = VideoGameProcessor.CreateVideoGame(videoGame.GameTitle, videoGame.ReleaseYear, videoGame.Platform, videoGame.Publisher, videoGame.CompleteCopy, videoGame.PhysicalCopy);
                return RedirectToAction("Index"); // If data is valid it will post to the DB
            }

            return View(); // If data is invalid it will return the View
        }

        public IActionResult RemoveGame() // Same as AddGame()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
