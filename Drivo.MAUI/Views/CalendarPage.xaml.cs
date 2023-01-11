using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class CalendarPage : ContentPage
{
	public CalendarPage(CalendarPageViewModel calendarPageViewModel)
	{
		InitializeComponent();

		BindingContext = calendarPageViewModel;
	}
}