using Grind.ViewModel;

namespace Grind.View;

public partial class TrackersPage : ContentPage
{
	public TrackersPage(TrackersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}