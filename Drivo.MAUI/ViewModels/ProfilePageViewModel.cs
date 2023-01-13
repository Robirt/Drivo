using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class ProfilePageViewModel : ViewModelBase
{
    public ProfilePageViewModel(UserService userService)
    {
        UserService = userService;

        GoToCalendarPageCommand = new Command(GoToExternalExamAddPageAsync);
        SignOutCommand = new Command(SignOutAsync);
    }

    private UserService UserService { get; }

    private UserEntity user;
    public UserEntity User
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

    public Command SignOutCommand { get; set; }

    public Command GoToCalendarPageCommand { get; set; }

    private List<PaymentEntity> payments;
    public List<PaymentEntity> Payments
    {
        get
        {
            return payments;
        }

        set
        {
            if (payments == value) return;
            payments = value;
            OnPropertyChanged(nameof(Payments));
        }
    }

    private async void GoToExternalExamAddPageAsync()
    {
        await Shell.Current.GoToAsync("ExternalExamAdd");
    }

    private async void SignOutAsync()
    {
        await UserService.SignOutAsync();

        await Shell.Current.GoToAsync("//SignIn");
    }
}