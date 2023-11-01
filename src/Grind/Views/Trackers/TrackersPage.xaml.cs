using Grind.ViewsModels;

namespace Grind.Views;

public partial class TrackersPage : ContentPage
{
	public TrackersPage(TrackersViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}