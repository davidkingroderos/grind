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

namespace Grind.ViewModels
{
    public partial class FinishedTodosViewModel : TodosViewModel
    {
        public ObservableCollection<Todo> FinishedTodos { get; set; } = new();
        public ObservableCollection<TodoGroup> FinishedTodoGroups { get; set; } = new();

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
                FinishedTodoGroups.Clear();

                var todos = await TodoService.GetTodosAsync();

                HashSet<string> finishedTodoColors = new();

                foreach (Todo todo in todos)
                {
                    if (todo.IsCompleted == 1)
                    {
                        finishedTodoColors.Add(todo.Color);

                        todo.ThemeColor = CatppuccinColorConverter.GetColor(todo.Color);
                        FinishedTodos.Add(todo);
                    }
                }

                foreach (string finishedTodoColor in finishedTodoColors)
                {
                    var finishedTodoGroup = FinishedTodos.Where(t => t.Color == finishedTodoColor);
                    FinishedTodoGroups.Add(new TodoGroup(finishedTodoColor, new ObservableCollection<Todo>(finishedTodoGroup)));
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

                // This part of the code can be optimized by just removing an item in a group not clearing the whole todo (I don't know how btw)
                FinishedTodoGroups.Clear();

                HashSet<string> finishedTodoColors = new();

                foreach (Todo finishedTodo in FinishedTodos)
                {
                    finishedTodoColors.Add(finishedTodo.Color);
                }

                foreach (string finishedTodoColor in finishedTodoColors)
                {
                    var finishedTodoGroup = FinishedTodos.Where(t => t.Color == finishedTodoColor);
                    FinishedTodoGroups.Add(new TodoGroup(finishedTodoColor, new ObservableCollection<Todo>(finishedTodoGroup)));
                }
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
