using Drivo.Entities;
using Drivo.MAUI.Services;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Drivo.MAUI.ViewModels;

public class HomePageViewModel : INotifyPropertyChanged
{
    public HomePageViewModel(UserService userService)
    {
        UserService = userService;

        GetUserAsync();
    }

    private UserService UserService { get; }

    private StudentEntity user;

    public event PropertyChangedEventHandler PropertyChanged;

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
            OnPropertyChanged();
        }
    }

    public LectureEntity NextLecture => User.StudentsGroup.Lectures.LastOrDefault();

    private DrivingEntity nextDriving;
    public DrivingEntity NextDriving
    {
        get
        {
            return nextDriving;
        }

        set
        {
            if (nextDriving == value) return;
            nextDriving = value;
            OnPropertyChanged();
        }
    }

    public ExternalExamEntity NextExternalExam => User.ExternalExams.LastOrDefault();

    public async Task GetUserAsync()
    {
        User = await UserService.GetUserAsync();

        User = User;

        NextDriving = User.Drivings.LastOrDefault();

        OnPropertyChanged();
    }

    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
