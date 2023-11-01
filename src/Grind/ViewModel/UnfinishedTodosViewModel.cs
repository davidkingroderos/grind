using CommunityToolkit.Mvvm.Input;
using Grind.Model;
using Grind.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class UnfinishedTodosViewModel : TodosViewModel
    {
        public ObservableCollection<Todo> UnfinishedTodos { get; set; } = new();

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

                var unfinishedTodos = await TodoService.GetTodosAsync();

                foreach (Todo todo in unfinishedTodos)
                {
                    if (todo.IsCompleted == 0)
                    {
                        todo.ThemeColor = CatppuccinColorConverter.GetColor(todo.Color);
                        UnfinishedTodos.Add(todo);
                    }
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
