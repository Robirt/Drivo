using Drivo.Entities;
using Drivo.MAUI.Services;

namespace Drivo.MAUI.ViewModels;

public class ProfilePageViewModel : ViewModelBase
{
    public ProfilePageViewModel(UserService userService)
    {
        UserService = userService;

        GoToExternalExamAddPageCommand = new Command(GoToExternalExamAddPageAsync);
        SignOutCommand = new Command(SignOutAsync);

        User = new StudentEntity();
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

    public PaymentEntity NextPayment => User.Payments.LastOrDefault();

    public async Task GetUserAsync()
    {
        //User = await UserService.GetUserAsync();
        User = new StudentEntity();
        User.FirstName = "James";
        User.LastName = "Doe";
        User.BirthDate = DateTime.Now;
        User.Email = "Siema";
        User.PhoneNumber = "500500500";
        User.Payments = new List<PaymentEntity>();
        User.Payments.Add(new PaymentEntity() { EndDate = DateTime.Now, Ammount = 250, IsApproved = true });

        OnPropertyChanged(nameof(User));
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