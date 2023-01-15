using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

[QueryProperty(nameof(CourseModuleName), "CourseModuleName")]
public class CourseModulePageViewModel : ViewModelBase
{
    public CourseModulePageViewModel(CourseModulesService courseModulesService)
    {
        CourseModulesService = courseModulesService;

        CourseModule = new CourseModuleEntity();

        GetCourseModuleByNameAsync();
    }

    private CourseModulesService CourseModulesService { get; }

    private string courseModuleName;
    public string CourseModuleName
    {
        get
        {
            return courseModuleName;
        }

        set
        {
            if (courseModuleName == value) return;
            courseModuleName = value;
            OnPropertyChanged(nameof(CourseModuleName));
        }
    }

    private CourseModuleEntity courseModule;
    public CourseModuleEntity CourseModule
    {
        get
        {
            return courseModule;
        }

        set
        {
            if (courseModule == value) return;
            courseModule = value;
            OnPropertyChanged(nameof(CourseModule));
        }
    }

    public async Task GetCourseModuleByNameAsync()
    {
        CourseModule = await CourseModulesService.GetCourseModuleByNameAsync(courseModuleName);
    }
}
