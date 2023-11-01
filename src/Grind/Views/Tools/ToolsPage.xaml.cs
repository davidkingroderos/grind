using Grind.ViewsModels;

namespace Grind.Views;

public partial class ToolsPage : ContentPage
{
	public ToolsPage(ToolsViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}
}