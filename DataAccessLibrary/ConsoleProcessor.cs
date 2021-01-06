using DataAccessLibrary.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccessLibrary
{
    public static class ConsoleProcessor
    {
        public static int CreateConsole(string ConsoleName, string Manufacturer, string Notes)
        {
            ConsoleModel data = new ConsoleModel
            {
                ConsoleName = ConsoleName,
                Manufacturer = Manufacturer,
                Notes = Notes
            };

            string sql = "insert into Console (ConsoleName, Manufacturer, Notes) values (@ConsoleName, @Manufacturer, @Notes);";

            return SQLiteDataAccess.SaveData(sql, data);
        }

        public static List<ConsoleModel> LoadConsole()
        {
            string sql = "select Id, ConsoleName, Manufacturer, Notes from Console;";

            return SQLiteDataAccess.LoadData<ConsoleModel>(sql);
        }
    }
}
