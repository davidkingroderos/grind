using Grind.ViewModel;

namespace Grind.View;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage(AddTodoViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}