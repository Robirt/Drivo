using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class CourseModulesPageViewModel : ViewModelBase
{
    public CourseModulesPageViewModel(CourseModulesService courseModulesService)
    {
        CourseModulesService = courseModulesService;

        GoToCourseModulePageCommand = new Command<string>(async (string name) => {
            await Shell.Current.GoToAsync($"CourseModule?CourseModuleName={name}");        
        });

        GetCourseModulesAsync();
    }

    private CourseModulesService CourseModulesService { get; }

    public Command<string> GoToCourseModulePageCommand { get; set; }

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
}
