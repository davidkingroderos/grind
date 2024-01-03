using Grind.ViewModels;

namespace Grind.Views;

public partial class RoutinesPage : ContentPage
{
	public RoutinesPage(RoutinesViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}