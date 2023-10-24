using Grind.ViewModel;

namespace Grind.View;

public partial class TodosPage : ContentPage
{
	public TodosPage(TodosViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}