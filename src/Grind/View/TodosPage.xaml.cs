using Grind.ViewModel;

namespace Grind.View;

public partial class TodosPage : ContentPage
{
	public TodosPage(UnfinishedTodosViewModel viewModel)
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