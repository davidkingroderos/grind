using Grind.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Services
{
    public class TrackerService
    {
        private static SQLiteAsyncConnection Database;

        private static async Task Init()
        {
            if (Database is not null)
            {
                return;
            }

            string databaseFilename = "Trackers_db";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

            SQLite.SQLiteOpenFlags flags =
                SQLite.SQLiteOpenFlags.ReadWrite |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            Database = new SQLiteAsyncConnection(databasePath, flags);

            await Database.CreateTableAsync<Tracker>();
        }

        public static async Task AddTrackerAsync(Tracker tracker)
        {
            await Init();

            await Database.InsertAsync(tracker);
        }

        public static async Task RemoveTrackerAsync(int id)
        {
            await Init();

            await Database.DeleteAsync<Tracker>(id);
        }

        public static async Task<Tracker> GetTrackerAsync(int id)
        {
            await Init();

            var tracker = await Database.GetAsync<Tracker>(id);

            return tracker;
        }

        public static async Task<IEnumerable<Tracker>> GetTrackersAsync()
        {
            await Init();

            var tracker = await Database.Table<Tracker>().ToListAsync();

            return tracker;
        }

        public static async Task UpdateTrackerAsync(Tracker tracker)
        {
            await Init();

            await Database.UpdateAsync(tracker);
        }
    }
}
