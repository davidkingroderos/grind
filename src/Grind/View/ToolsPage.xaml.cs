using Grind.ViewModel;

namespace Grind.View;

public partial class ToolsPage : ContentPage
{
	public ToolsPage(ToolsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}