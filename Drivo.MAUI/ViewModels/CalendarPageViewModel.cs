using Drivo.Entities;

namespace Drivo.MAUI.ViewModels;

public class CalendarPageViewModel : ViewModelBase
{
    public CalendarPageViewModel()
    {
        Ads = new List<AdEntity>();

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
}
