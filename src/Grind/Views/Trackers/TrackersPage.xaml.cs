using Grind.ViewModels;

namespace Grind.Views;

public partial class TrackersPage : ContentPage
{
	public TrackersPage(TrackersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}