using Grind.Views;

namespace Grind
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(AddTrackerPage), typeof(AddTrackerPage));
            Routing.RegisterRoute(nameof(AddTodoPage), typeof(AddTodoPage));
            Routing.RegisterRoute(nameof(AddRoutinePage), typeof(AddRoutinePage));
            Routing.RegisterRoute(nameof(TrackerDetailsPage), typeof(TrackerDetailsPage));
            Routing.RegisterRoute(nameof(TodoDetailsPage), typeof(TodoDetailsPage));
        }
    }
}