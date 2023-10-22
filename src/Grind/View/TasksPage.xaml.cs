using Grind.ViewModel;

namespace Grind.View;

public partial class TasksPage : ContentPage
{
	public TasksPage()
	{
		InitializeComponent();

		BindingContext = new TasksViewModel();
	}
}