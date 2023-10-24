using CommunityToolkit.Mvvm.Input;
using Grind.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class RoutinesViewModel : BaseViewModel
    {
        public RoutinesViewModel()
        {
            Title = "Routines";
        }

        [RelayCommand]
        private async Task GoToAddRoutineAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddRoutinePage)}", true);
        }
    }
}
