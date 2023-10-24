using Grind.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Services
{
    public class RoutineService
    {
        private static SQLiteAsyncConnection Database;

        private static async Task Init()
        {
            if (Database is not null)
            {
                return;
            }

            string databaseFilename = "Routines_db";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

            SQLite.SQLiteOpenFlags flags =
                SQLite.SQLiteOpenFlags.ReadWrite |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            Database = new SQLiteAsyncConnection(databasePath, flags);

            await Database.CreateTableAsync<Routine>();
        }

        public static async Task AddRoutineAsync(Routine routine)
        {
            await Init();

            await Database.InsertAsync(routine);
        }

        public static async Task RemoveRoutineAsync(int id)
        {
            await Init();

            await Database.DeleteAsync<Routine>(id);
        }

        public static async Task<Routine> GetRoutineAsync(int id)
        {
            await Init();

            var routine = await Database.GetAsync<Routine>(id);

            return routine;
        }

        public static async Task<IEnumerable<Routine>> GetRoutinesAsync()
        {
            await Init();

            var routine = await Database.Table<Routine>().ToListAsync();

            return routine;
        }

        public static async Task UpdateRoutineAsync(Routine routine)
        {
            await Init();

            await Database.UpdateAsync(routine);
        }
    }
}
