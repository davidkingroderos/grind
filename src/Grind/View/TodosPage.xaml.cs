using Grind.ViewModel;

namespace Grind.View;

public partial class TodosPage : ContentPage
{
	public TodosPage()
	{
		InitializeComponent();

		BindingContext = new TodosViewModel();
	}
}