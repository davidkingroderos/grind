using CommunityToolkit.Mvvm.Input;
using Grind.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class TasksViewModel : BaseViewModel
    {
        [RelayCommand]
        private async Task GoToAddTaskAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTaskPage)}", true);
        }
    }
}
