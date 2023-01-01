using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class CourseModulesPageViewModel : ViewModelBase
{
    public CourseModulesPageViewModel(UserService userService, HttpClient httpClient)
    {
        UserService = userService;
        HttpClient = httpClient;
        GoToResourcesPageCommand = new Command(GoToResourcesPage);
    }
    private UserService UserService { get; }
    private HttpClient HttpClient { get; }
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
    public Command GoToResourcesPageCommand { get; set; }
    private async void GoToResourcesPage()
    {
        await Shell.Current.GoToAsync("//ResourcesPage");
    }
}
