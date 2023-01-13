using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class CourseModulePage : ContentPage
{
	public CourseModulePage(CourseModulePageViewModel courseModulePageViewModel)
	{
		InitializeComponent();

		BindingContext = courseModulePageViewModel;
	}

    protected override async void OnAppearing()
    {
        base.OnAppearing();
    }
}