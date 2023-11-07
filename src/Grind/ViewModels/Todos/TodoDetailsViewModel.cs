using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grind.Models;
using Grind.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewsModels
{
    [QueryProperty("Todo", "Todo")]
    public partial class TodoDetailsViewModel : BaseViewModel
    {
        public TodoDetailsViewModel()
        {
            Application.Current.RequestedThemeChanged += (s, a) =>
            {
                Todo.ThemeColor = CatppuccinColorConverter.GetColor(Todo.Color);
            };
        }

        [ObservableProperty]
        private Todo todo;

        [ObservableProperty]
        private string color;

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string description;

        [RelayCommand]
        private async Task UpdateTodoAsync()
        {
            if (IsBusy)
                return;

            try
            {
                IsBusy = true;

                 
                
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.DisplayAlert("Error!", $"Unable to get todos: {ex.Message}", "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
    }
}
