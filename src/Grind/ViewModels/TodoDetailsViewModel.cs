using CommunityToolkit.Mvvm.ComponentModel;
using Grind.Models;
using System;
using System.Collections.Generic;
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
        }

        [ObservableProperty]
        private Todo todo;
    }
}
