using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class CalendarPageViewModel : ViewModelBase
{
    public CalendarPageViewModel(UserService userService, AdsService adsService)
    {
        UserService = userService;
        AdsService = adsService;

        GetUserAsync();

        Ads = new List<AdEntity>();
        GetAdsAsync();
    }

    private UserService UserService { get; }
    private AdsService AdsService { get; }

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

    private List<EventEntity> events;
    public List<EventEntity> Events
    {
        get
        {
            return events;
        }

        set
        {
            if (events == value) return;
            events = value;
            OnPropertyChanged(nameof(Events));
        }
    }

    private List<AdEntity> ads;
    public List<AdEntity> Ads
    {
        get
        {
            return ads;
        }

        set
        {
            if (ads == value) return;
            ads = value;
            OnPropertyChanged(nameof(Ads));
        }
    }

    public async Task GetUserAsync()
    {
        User = await UserService.GetUserAsync();

        Events = new List<EventEntity>();
        Events.AddRange(User.StudentsGroup.Lectures);
        Events.AddRange(User.Drivings);
        Events.AddRange(User.InternalExams);
        Events.AddRange(User.ExternalExams);
    }

    public async Task GetAdsAsync()
    {
        Ads = await AdsService.GetAdsAsync();
    }
}
