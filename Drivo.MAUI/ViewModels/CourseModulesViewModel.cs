namespace Drivo.MAUI.ViewModels;

public class CourseModulesViewModel : ViewModelBase
{
    private List<CourseModule> courseModules;
    public List<CourseModule> CourseModules
    {
        get
        {
            return courseModules;
        }
        set
        {
            courseModules = value;
        }
    }
}

public class CourseModule
{
    public int Id { get; set; }

    public string Title { get; set; }

    public byte[] Image { get; set; }
}
