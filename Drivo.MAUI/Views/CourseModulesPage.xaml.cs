using Drivo.MAUI.ViewModels;

namespace Drivo.MAUI.Views;

public partial class CourseModulesPage : ContentPage
{
	public CourseModulesPage(CourseModulesPageViewModel courseModulePageViewModel)
	{
		InitializeComponent();
		try
		{
            BindingContext = courseModulePageViewModel;
        }

		catch (Exception ex) {
		}
	}

    protected async override void OnAppearing()
    {
		try
		{
            await (BindingContext as CourseModulesPageViewModel).GetCourseModulesAsync();
        }

		catch (Exception ex)
		{
			var d = ex;
			var z = ex.InnerException;
		}
    }
}