using Grind.ViewModels;

namespace Grind.Views;

public partial class TrackerDetailsPage : ContentPage
{
	public TrackerDetailsPage(TrackerDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}