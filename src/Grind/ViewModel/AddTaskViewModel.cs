using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class AddTaskViewModel : BaseViewModel
    {
        public AddTaskViewModel()
        {
            Title = "Add Task";
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

        [RelayCommand]
        private async Task AddTaskAsync()
        {

        }
    }
}
