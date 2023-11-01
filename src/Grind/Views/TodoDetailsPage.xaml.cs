using Grind.ViewsModels;

namespace Grind.Views;

public partial class TodoDetailsPage : ContentPage
{
	public TodoDetailsPage(TodoDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}