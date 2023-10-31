using Grind.ViewModel;

namespace Grind.View;

public partial class CompletedTodosPage : ContentPage
{
	public CompletedTodosPage(TodosViewModel viewModel)
	{
		InitializeComponent();

		BindingContext = viewModel;
	}

    protected override void OnNavigatedTo(NavigatedToEventArgs args)
    {
        base.OnNavigatedTo(args);

		var viewModel = BindingContext as TodosViewModel;

		if (viewModel.GetTodosCommand.CanExecute(null))
		{
			viewModel.GetTodosCommand.Execute(null);
		}
    }
}