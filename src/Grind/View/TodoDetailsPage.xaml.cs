using Grind.ViewModel;

namespace Grind.View;

public partial class TodoDetailsPage : ContentPage
{
	public TodoDetailsPage(TodoDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}