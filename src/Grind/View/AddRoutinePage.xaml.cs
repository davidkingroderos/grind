using Grind.ViewModel;

namespace Grind.View;

public partial class AddRoutinePage : ContentPage
{
	public AddRoutinePage(AddRoutineViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}