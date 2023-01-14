using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel(UserService userService)
    {
        UserService = userService;

        GetUserAsync();
    }

    private UserService UserService { get; }

    private StudentEntity user;
    public StudentEntity User
    {
        get
        {
            return user;
        }

        set
        {
            if (user == value) return;
            user = value;
            OnPropertyChanged(nameof(User));
        }
    }

    public LectureEntity NextLecture => User.StudentsGroup.Lectures.LastOrDefault();

    public DrivingEntity NextDriving => User.Drivings.LastOrDefault();

    public InternalExamEntity NextInternalExam => User.InternalExams.LastOrDefault();

    public ExternalExamEntity NextExternalExam => User.ExternalExams.LastOrDefault();

    public async Task GetUserAsync()
    {
        //Student = await UserService.GetUserAsync();

        User = new StudentEntity();
        User.StudentsGroup = new StudentsGroupEntity()
        {
            Lectures = new List<LectureEntity>()
            {
                new LectureEntity(){ Place = "D", StartDate = DateTime.Now }
            }
        };

        User.InternalExams = new List<InternalExamEntity>()
        {
            new InternalExamEntity()
            {
                Place = "sa",
                StartDate = DateTime.Now
            }
        };

        User.ExternalExams = new List<ExternalExamEntity>()
        {
            new ExternalExamEntity{ Place = "sa", StartDate = DateTime.Now}
        };

        User.Drivings = new List<DrivingEntity>()
        {
            new DrivingEntity(){Place = "Dupa", StartDate = DateTime.Now}
        };
    }
}
