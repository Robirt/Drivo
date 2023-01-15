using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage(CalendarPageViewModel calendarPageViewModel)
	{
		InitializeComponent();

		BindingContext = calendarPageViewModel;
	}

    protected async override void OnAppearing()
    {
		await (BindingContext as CalendarPageViewModel).GetUserAsync();

        base.OnAppearing();
    }
}