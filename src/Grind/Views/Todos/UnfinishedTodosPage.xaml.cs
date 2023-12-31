using Grind.ViewModels;

namespace Grind.Views;

public partial class UnfinishedTodosPage : ContentPage
{
	public UnfinishedTodosPage(UnfinishedTodosViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		var viewModel = BindingContext as UnfinishedTodosViewModel;

		if (viewModel.GetUnfinishedTodosCommand.CanExecute(null))
		{
			viewModel.GetUnfinishedTodosCommand.Execute(null);
		}
    }
}