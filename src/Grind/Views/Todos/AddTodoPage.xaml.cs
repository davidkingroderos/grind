using Grind.ViewModels;

namespace Grind.Views;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage(AddTodoViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}