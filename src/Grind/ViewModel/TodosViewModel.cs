using CommunityToolkit.Mvvm.Input;
using Grind.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewModel
{
    public partial class TodosViewModel : BaseViewModel
    {
        [RelayCommand]
        private async Task GoToAddTodoAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTodoPage)}", true);
        }
    }
}
