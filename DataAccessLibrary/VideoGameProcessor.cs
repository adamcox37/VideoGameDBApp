using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary
{
    public static class VideoGameProcessor
    {
        // Saves data from the Add Games form
        public static int CreateVideoGame(string GameTitle, string ReleaseYear, string Platform, string Publisher, bool CompleteCopy, bool PhsyicalCopy)
        {
            // Linking the MVC and Library Models
            VideoGameModel data = new VideoGameModel
            {
                GameTitle = GameTitle,
                ReleaseYear = ReleaseYear,
                Platform = Platform,
                Publisher = Publisher,
                CompleteCopy = CompleteCopy,
                PhysicalCopy = PhsyicalCopy
            };

            // SQLite statement that adds the game info into the VideoGames table
            string sql = @"insert into VideoGames (GameTitle, ReleaseYear, Platform, Publisher, CompleteCopy, PhysicalCopy) 
                           values (@GameTitle, @ReleaseYear, @Platform, @Publisher, @CompleteCopy, @PhysicalCopy);";

            return SQLiteDataAccess.SaveData(sql, data);
        }

        // Loads data from the Add Games form into the Table
        public static List<VideoGameModel> LoadGames()
        {
            string sql = "select Id, GameTitle, ReleaseYear, Platform, Publisher, CompleteCopy, PhysicalCopy from VideoGames;";

            return SQLiteDataAccess.LoadData<VideoGameModel>(sql);
        }
    }
}
