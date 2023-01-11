using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class CourseModulesPageViewModel : ViewModelBase
{
    public CourseModulesPageViewModel(CourseModulesService courseModulesService)
    {
        CourseModulesService = courseModulesService;
    }

    private CourseModulesService CourseModulesService { get; }
        
    private List<CourseModuleEntity> courseModules;
    public List<CourseModuleEntity> CourseModules
    {
 
        get
        {
            return courseModules;
        }

        set
        {
            if (courseModules == value) return;
            courseModules = value;
            OnPropertyChanged(nameof(CourseModules));
        }
    }

    public async Task GetCourseModulesAsync()
    {
        CourseModules = await CourseModulesService.GetCourseModulesAsync();
    }

    public Command GoToResourcesPageCommand { get; set; }
    private async void GoToResourcesPage()
    {
        await Shell.Current.GoToAsync("//ResourcesPage");
    }
}
