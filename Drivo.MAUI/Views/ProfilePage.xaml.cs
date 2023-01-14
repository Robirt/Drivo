using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class ProfilePage : ContentPage
{
	public ProfilePage(ProfilePageViewModel profilePageViewModel)
	{
		InitializeComponent();

		BindingContext = profilePageViewModel;
	}

    protected async override void OnAppearing()
    {
        base.OnAppearing();

        await (BindingContext as ProfilePageViewModel).GetUserAsync();
    }
}