using Grind.ViewModels;

namespace Grind.Views;

public partial class AddRoutinePage : ContentPage
{
	public AddRoutinePage(AddRoutineViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}