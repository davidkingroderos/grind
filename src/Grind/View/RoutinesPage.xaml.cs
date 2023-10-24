using Grind.ViewModel;

namespace Grind.View;

public partial class RoutinesPage : ContentPage
{
	public RoutinesPage(RoutinesViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}