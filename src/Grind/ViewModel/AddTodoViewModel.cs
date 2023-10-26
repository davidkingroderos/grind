using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grind.Model;
using Grind.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class AddTodoViewModel : BaseViewModel
    {
        public AddTodoViewModel()
        {
            Title = "Add Todo";
        }

        [ObservableProperty]
        public string name;

        [ObservableProperty]
        public string description;

        [ObservableProperty]
        public int isCompleted;

        [ObservableProperty]
        public string dateCreated;

        [ObservableProperty]
        public string deadlineDate;

        [ObservableProperty]
        public string color;

        [RelayCommand]
        private async Task AddTodoAsync()
        {
            if (Name is null || Name.Equals(""))
            {
                await Shell.Current.CurrentPage.DisplayAlert("Empty Name",
                    "Please enter a name of your todo", "OK");

                return;
            }

            if (Color is null)
            {
                await Shell.Current.CurrentPage.DisplayAlert("Invalid Color",
                    "Please choose a color", "OK");

                return;
            }

            try
            {
                await TodoService.AddTodoAsync(new Todo()
                {
                    Name = Name,
                    Description = Description is null ? "" : Description,
                    DeadlineDate = DeadlineDate is null ? DateTime.Now.ToShortDateString() : DeadlineDate,
                    Color = Color,
                });

                await Shell.Current.CurrentPage.DisplayAlert("Success!",
                    $"Train schedule added", "OK");
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
