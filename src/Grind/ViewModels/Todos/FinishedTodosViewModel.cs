using CommunityToolkit.Mvvm.Input;
using Grind.Models;
using Grind.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewsModels
{
    public partial class FinishedTodosViewModel : TodosViewModel
    {
        public ObservableCollection<Todo> FinishedTodos { get; set; } = new();

        public FinishedTodosViewModel()
        {
            Application.Current.RequestedThemeChanged += async (s, a) => await GetFinishedTodosAsync();
        }

        [RelayCommand]
        private async Task GetFinishedTodosAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                FinishedTodos.Clear();

                var todos = await TodoService.GetTodosAsync();

                foreach (Todo todo in todos)
                {
                    if (todo.IsCompleted == 1)
                    {
                        todo.ThemeColor = CatppuccinColorConverter.GetColor(todo.Color);
                        FinishedTodos.Add(todo);
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get finished todos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task MarkTodoAsUnfinishedAsync(Todo todo)
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                todo.IsCompleted = 0;

                await TodoService.UpdateTodoAsync(todo);

                FinishedTodos.Remove(todo);
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to mark todo as unfinished: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
