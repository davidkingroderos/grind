using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Services
{
    public class TaskService
    {
        private static SQLiteAsyncConnection Database;

        private static async Task Init()
        {
            if (Database is not null)
            {
                return;
            }

            string databaseFilename = "Tasks_db";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

            SQLite.SQLiteOpenFlags flags =
                SQLite.SQLiteOpenFlags.ReadWrite |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            Database = new SQLiteAsyncConnection(databasePath, flags);

            await Database.CreateTableAsync<Model.Task>();
        }
    }
}
