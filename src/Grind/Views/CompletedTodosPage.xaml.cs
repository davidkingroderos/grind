using Grind.ViewsModels;

namespace Grind.Views;

public partial class CompletedTodosPage : ContentPage
{
	public CompletedTodosPage(FinishedTodosViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		var viewModel = BindingContext as FinishedTodosViewModel;

		if (viewModel.GetFinishedTodosCommand.CanExecute(null))
		{
			viewModel.GetFinishedTodosCommand.Execute(null);
		}
    }
}