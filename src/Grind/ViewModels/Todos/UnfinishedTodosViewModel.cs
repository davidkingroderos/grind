using CommunityToolkit.Mvvm.Input;
using Grind.Models;
using Grind.Services;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewsModels
{
    public partial class UnfinishedTodosViewModel : TodosViewModel
    {
        public ObservableCollection<Todo> UnfinishedTodos { get; set; } = new();
        public ObservableCollection<Grouping<string, Todo>> UnfinishedTodoGroups { get; set; } = new();

        public UnfinishedTodosViewModel()
        {
            Application.Current.RequestedThemeChanged += async (s, a) => await GetUnfinishedTodosAsync();
        }

        [RelayCommand]
        private async Task GetUnfinishedTodosAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                UnfinishedTodos.Clear();
                UnfinishedTodoGroups.Clear();

                var todos = await TodoService.GetTodosAsync();
                HashSet<string> unfinishedTodoColors = new();

                foreach (Todo todo in todos)
                {
                    if (todo.IsCompleted == 0)
                    {
                        unfinishedTodoColors.Add(todo.Color);

                        todo.ThemeColor = CatppuccinColorConverter.GetColor(todo.Color);
                        UnfinishedTodos.Add(todo);
                    }
                }

                foreach (string unfinishedTodoColor in unfinishedTodoColors)
                {
                    UnfinishedTodoGroups.Add(new Grouping<string, Todo>(unfinishedTodoColor, UnfinishedTodos.Where(t => t.Color == unfinishedTodoColor)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get unfinished todos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task MarkTodoAsFinishedAsync(Todo todo)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                todo.IsCompleted = 1;

                await TodoService.UpdateTodoAsync(todo);

                UnfinishedTodos.Remove(todo);

                // This part of the code can be optimized by just removing an item in a group not clearing the whole todo
                UnfinishedTodoGroups.Clear();

                HashSet<string> unfinishedTodoColors = new();

                foreach (Todo unfinishedTodo in UnfinishedTodos)
                {
                    unfinishedTodoColors.Add(unfinishedTodo.Color);
                }

                foreach (string unfinishedTodoColor in unfinishedTodoColors)
                {
                    UnfinishedTodoGroups.Add(new Grouping<string, Todo>(unfinishedTodoColor, UnfinishedTodos.Where(t => t.Color == unfinishedTodoColor)));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to mark todo as finished: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
