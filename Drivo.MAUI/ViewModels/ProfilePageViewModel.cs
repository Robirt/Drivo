using Drivo.Entities;
using Drivo.MAUI.Services;
using System.Collections.ObjectModel;

namespace Drivo.MAUI.ViewModels;

public class ProfilePageViewModel : ViewModelBase
{
    public ProfilePageViewModel(UserService userService)
    {
        UserService = userService;

        GoToExternalExamAddPageCommand = new Command(GoToExternalExamAddPageAsync);
        SignOutCommand = new Command(SignOutAsync);

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

    public Command SignOutCommand { get; set; }

    public Command GoToExternalExamAddPageCommand { get; set; }

    public ObservableCollection<PaymentEntity> Payments
    {
        get => new ObservableCollection<PaymentEntity>(User.Payments);
    }

    public async Task GetUserAsync()
    {
        User = await UserService.GetUserAsync();
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