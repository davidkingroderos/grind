using Grind.View;

namespace Grind
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddTrackerPage), typeof(AddTrackerPage));
        }
    }
}