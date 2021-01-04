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
        SQLiteCommand command = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteConnection connection = new SQLiteConnection();
        List<VideoGameModel> games = new List<VideoGameModel>();
        List<ConsoleModel> systems = new List<ConsoleModel>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connection.ConnectionString = VideoGameCatolog.Properties.Resources.ConnectionString; // ConnectionString to SQLite DB
        }

        public IActionResult Index()
        {
            GetData();
            return View(games);
        }

        public IActionResult ConsoleDB()
        {
            GetData();
            return View(systems);
        }

        private void GetData() // The SQLite data
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select Id, GameTitle, ReleaseYear, Platform, Publisher, CompleteCopy, PhsyicalCopy from VideoGames";
                command.CommandText = "Select Id, ConsoleName, Manufacturer, Notes from Console";
                dr = command.ExecuteReader();
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
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
