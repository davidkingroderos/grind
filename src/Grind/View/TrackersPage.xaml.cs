using Grind.ViewModel;

namespace Grind.View;

public partial class TrackersPage : ContentPage
{
	public TrackersPage()
	{
		InitializeComponent();

		BindingContext = new TrackersViewModel();
	}
}