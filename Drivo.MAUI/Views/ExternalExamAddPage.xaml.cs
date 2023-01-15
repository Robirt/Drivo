using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class ExternalExamAddPage : ContentPage
{
	public ExternalExamAddPage(ExternalExamAddPageViewModel externalExamAddPageViewModel)
	{
		InitializeComponent();

		BindingContext = externalExamAddPageViewModel;
	}
}