using Grind.ViewModel;

namespace Grind.View;

public partial class CompletedTodosPage : ContentPage
{
	public CompletedTodosPage(TodosViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}