using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary
{
    public class SQLiteCrud
    {
        private readonly string _connectionString;
        private SQLiteDataAccess db = new SQLiteDataAccess();
        public SQLiteCrud(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<VideoGameModel> GetAllGames()
        {
            string sql = "Select Id, GameTitle, ReleaseYear, Platform, Publisher, CompleteCopy, PhsyicalCopy from VideoGames";
            return db.LoadData<VideoGameModel, dynamic>(sql, new { }, _connectionString);
        }

        public List<ConsoleModel> GetAllSystems()
        {
            string sql = "Select Id, ConsoleName from Console";
            return db.LoadData<ConsoleModel, dynamic>(sql, new { }, _connectionString);
        }
    }
}
