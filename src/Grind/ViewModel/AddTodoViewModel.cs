using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
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
        private async Task AddTaskAsync()
        {

        }
    }
}
