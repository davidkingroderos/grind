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
            try
            {



                await Shell.Current.CurrentPage.DisplayAlert("Success!",
                    $"Todo updated", "OK");

                await Shell.Current.GoToAsync("..");
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                await Shell.Current.CurrentPage.DisplayAlert("Error!",
                    $"Unable to add Todo: {ex.Message}", "OK");
            }
        }
    }
}
