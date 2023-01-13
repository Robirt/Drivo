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

        Events = new List<EventEntity>();
        GetEventsAsync();

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
            OnPropertyChanged(nameof(events));
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
    }

    public async Task GetEventsAsync()
    {
        for (int i = 0; i < 12; i++)
        {
            Events.Add(new DrivingEntity() { Name = "Siema", StartDate = DateTime.Now, Place = "Elo", EndDate = DateTime.Now.AddHours(3) });
        }
    }

    public async Task GetAdsAsync()
    {
        //Ads = await AdsService.GetAdsAsync();
        Ads.Add(new AdEntity() { Content = "Witam serdecznie, co tam u państwa słychać, ja się bawię wyśmienicie, nie wiem jak wy. Przedni fun, naprawdę. Dajcie mi już wszyscy kurwa, święty spokój.", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
        Ads.Add(new AdEntity() { Content = "Siema", Date = DateTime.Now });
    }
}
