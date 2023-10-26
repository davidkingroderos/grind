using Grind.ViewModel;

namespace Grind.View;

public partial class TrackerDetailsPage : ContentPage
{
	public TrackerDetailsPage(TrackerDetailsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}