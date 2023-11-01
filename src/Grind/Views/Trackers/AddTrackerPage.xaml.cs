using Grind.ViewsModels;

namespace Grind.Views;

public partial class AddTrackerPage : ContentPage
{
    public AddTrackerPage(AddTrackerViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}