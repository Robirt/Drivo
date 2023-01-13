using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class HomePage : ContentPage
{
    public HomePage(HomePageViewModel homePageViewModel)
    {
        InitializeComponent();
        
         BindingContext = homePageViewModel;
    }

    protected async override void OnAppearing()
    {
        await (BindingContext as HomePageViewModel).GetUserAsync();

        base.OnAppearing();
    }
}