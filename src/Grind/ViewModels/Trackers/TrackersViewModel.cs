using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Grind.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Grind.ViewsModels
{
    public partial class TrackersViewModel : BaseViewModel
    {
        [RelayCommand]
        private async Task GoToAddTrackerAsync()
        {
            await Shell.Current.GoToAsync($"{nameof(AddTrackerPage)}", true);
        }

        [ObservableProperty]
        [Obsolete]
        private Color aquaColor = Color.FromHex("FF6A00");
        [ObservableProperty]
        [Obsolete]
        private string maroonColorHex = "#18b542";
    }
}
