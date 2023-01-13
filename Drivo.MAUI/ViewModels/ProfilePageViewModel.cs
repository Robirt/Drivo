using Drivo.Entities;
using Drivo.MAUI.Services;
using Drivo.Requests;

namespace Drivo.MAUI.ViewModels;

public class ProfilePageViewModel : ViewModelBase
{
	public ProfilePageViewModel(UserService userService, HttpClient httpClient)
	{
		UserService = userService;
        HttpClient = httpClient;    
        SignOutCommand = new Command(SignOut);
        GoToCalendarPageCommand = new Command(GoToCalendarPage);


    }
    private UserService UserService { get; }
    private HttpClient HttpClient { get; }
    private UserEntity user;
    public UserEntity User
    {
        get { return user; }
        set { OnPropertyChanged(nameof(user)); }
    }
    public Command SignOutCommand { get; set; }
    private async void SignOut()
    {
        await UserService.SignOutAsync();
    }

    public Command GoToCalendarPageCommand { get; set; }
    private async void GoToCalendarPage()
    {
        await Shell.Current.GoToAsync("//CalendarPage");
    }

    private PaymentEntity nextPayment;
    public PaymentEntity NextPayment
    {
        get
        {
            return nextPayment;
        }

        set
        {
            if (nextPayment == value) return;
            nextPayment = value;
            OnPropertyChanged(nameof(NextPayment));
        }
    }
    private List<LectureEntity> lectures;
    public List<LectureEntity> Lectures
    {
        get
        {
            return lectures;
        }

        set
        {
            if (lectures == value) return;
            lectures = value;
            OnPropertyChanged(nameof(Lectures));
        }
    }

    private LectureEntity firstLecture;
    public LectureEntity FirstLecture
    {
        get
        {
            return firstLecture;
        }

        set
        {
            if (firstLecture == value) return;
            firstLecture = value;
            OnPropertyChanged(nameof(FirstLecture));
        }
    }

    private List<DrivingEntity> drivings;
    public List<DrivingEntity> Drivings
    {
        get
        {
            return drivings;
        }

        set
        {
            if (drivings == value) return;
            drivings = value;
            OnPropertyChanged(nameof(Drivings));
        }
    }
}