using Grind.ViewModels;

namespace Grind.Views;

public partial class ToolsPage : ContentPage
{
	public ToolsPage(ToolsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}