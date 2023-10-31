using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grind.Model;
using Grind.Services;
using Grind.View;
using Microsoft.Maui.Animations;
using MvvmHelpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class TodosViewModel : BaseViewModel
    {
        public ObservableCollection<Grouping<string, Todo>> TodoGroups { get; } = new();
        public ObservableCollection<Todo> Todos { get; } = new();

        public TodosViewModel()
        {
            Title = "Todos";
        }

        [ObservableProperty]
        private bool isRefreshing;

        [RelayCommand]
        private async Task GetTodosAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                Todos.Clear();

                var todos = await TodoService.GetTodosAsync();

                foreach (Todo todo in todos)
                {
                    todo.ThemeColor = CatppuccinColorConverter.GetColor(todo.Color);

                    if (todo.IsCompleted == 0)
                    {
                        Todos.Add(todo);
                    }
                    else
                    {
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get todos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
                IsRefreshing = false;
            }
        }

        [RelayCommand]
        private async Task GoToTodoDetailsAsync(Todo todo)
        {
            if (todo is null)
                return;

            await Shell.Current.GoToAsync($"{nameof(TodoDetailsPage)}",
                true, new Dictionary<string, object>
                {
                    { "Todo", todo }
                });

            await GetTodosAsync();
        }

        [RelayCommand]
        private async Task GoToAddTodoAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTodoPage)}", true);
        }
    }
}
