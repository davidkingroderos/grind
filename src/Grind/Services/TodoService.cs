using Grind.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.Services
{
    public class TodoService
    {
        private static SQLiteAsyncConnection Database;

        private static async Task Init()
        {
            if (Database is not null)
            {
                return;
            }

            string databaseFilename = "TodosDB";
            string databasePath = Path.Combine(FileSystem.AppDataDirectory, databaseFilename);

            SQLite.SQLiteOpenFlags flags =
                SQLite.SQLiteOpenFlags.ReadWrite |
                SQLite.SQLiteOpenFlags.Create |
                SQLite.SQLiteOpenFlags.SharedCache;

            Database = new SQLiteAsyncConnection(databasePath, flags);

            await Database.CreateTableAsync<Todo>();
        }

        public static async Task AddTodoAsync(Todo todo)
        {
            await Init();

            await Database.InsertAsync(todo);
        }

        public static async Task RemoveTodoAsync(int id)
        {
            await Init();

            await Database.DeleteAsync<Todo>(id);
        }

        public static async Task<Todo> GetTodoAsync(int id)
        {
            await Init();

            var todo = await Database.GetAsync<Todo>(id);

            return todo;
        }

        public static async Task<IEnumerable<Todo>> GetTodosAsync()
        {
            await Init();

            var todo = await Database.Table<Todo>().ToListAsync();

            return todo;
        }

        public static async Task UpdateTodoAsync(Todo todo)
        {
            await Init();

            await Database.UpdateAsync(todo);
        }
    }
}
