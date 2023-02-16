using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class SignInPage : ContentPage
{
	public SignInPage(SignInPageViewModel signInPageViewModel)
	{
		InitializeComponent();

		BindingContext = signInPageViewModel;
	}
}