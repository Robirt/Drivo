using Drivo.Entities;

namespace Drivo.MAUI.ViewModels;

public class HomePageViewModel : ViewModelBase
{
    public HomePageViewModel()
    {
        
        
    }
    private LectureEntity nextLecture;
    public LectureEntity NextLecture
    {
        get
        {
            return nextLecture;
        }

        set
        {
            if (nextLecture == value) return;
            nextLecture = value;
            OnPropertyChanged(nameof(NextLecture));
        }
    }

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
            OnPropertyChanged(nameof(NextDriving));
        }
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
    private AdEntity lastAd;
    public AdEntity LastAd
    {
        get
        {
            return lastAd;
        }

        set
        {
            if (lastAd == value) return;
            lastAd = value;
            OnPropertyChanged(nameof(LastAd));
        }
    }
}


