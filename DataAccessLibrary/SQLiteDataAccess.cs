using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Data.SQLite;
using Dapper;
using System.Linq;
using System.Configuration;

namespace DataAccessLibrary
{
    public static class SQLiteDataAccess
    {
        public static string GetConnectionString(string connectionName = "VideoGameDB")
        {
            return ConfigurationManager.ConnectionStrings[connectionName].ConnectionString;
        }
        public static List<T> LoadData<T, U>(string sql)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                return connection.Query<T>(sql).ToList();

            }
        }

        public static int SaveData<T>(string sql, T data)
        {
            using (IDbConnection connection = new SQLiteConnection(GetConnectionString()))
            {
                return connection.Execute(sql, data);
            }
        }

        internal static List<T> LoadData<T>(string sql)
        {
            throw new NotImplementedException();
        }
    }
}
