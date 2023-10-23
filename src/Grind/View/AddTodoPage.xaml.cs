using Grind.ViewModel;

namespace Grind.View;

public partial class AddTodoPage : ContentPage
{
	public AddTodoPage()
	{
		InitializeComponent();

		BindingContext = new AddTodoViewModel();
	}
}