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
using DataAccessLibrary.Models;

namespace VideoGameCatolog.Controllers
{
    public class HomeController : Controller
    {
        SQLiteCommand command = new SQLiteCommand();
        SQLiteDataReader dr;
        SQLiteConnection connection = new SQLiteConnection();
        List<VideoGameModel> game = new List<VideoGameModel>();
        List<ConsoleModel> system = new List<ConsoleModel>();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
            connection.ConnectionString = VideoGameCatolog.Properties.Resources.ConnectionString;
        }

        public IActionResult Index()
        {
            return View();
        }

        private void GetData()
        {
            try
            {
                connection.Open();
                command.Connection = connection;
                command.CommandText = "Select Id, GameTitle, ReleaseYear, Platform, Publisher, CompleteCopy, PhsyicalCopy from VideoGames";
                command.CommandText = "Select Id, ConsoleName from Console";
                dr = command.ExecuteReader();
                while (dr.Read())
                {
                    
                }
                connection.Close();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public IActionResult AddGame()
        {
            return View();
        }

        public IActionResult RemoveGame()
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
