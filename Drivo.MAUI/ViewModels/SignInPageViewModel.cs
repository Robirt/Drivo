using Drivo.MAUI.Services;
using Drivo.Requests;
using Drivo.Responses;
using System.Net.Http.Headers;

namespace Drivo.MAUI.ViewModels;

public class SignInPageViewModel : ViewModelBase
{
    public SignInPageViewModel(UserService userService, HttpClient httpClient)
    {
        UserService = userService;
        HttpClient = httpClient;

        SignInRequest = new SignInRequest();
        SignInResponse = new SignInResponse();
        SignInCommand = new Command(SignInAsync);

        CheckIsUserSignedIn();
    }

    private UserService UserService { get; }

    private HttpClient HttpClient { get; }

    private SignInRequest signInRequest;
    public SignInRequest SignInRequest
    {
        get
        {
            return signInRequest;
        }
        set
        {
            if (signInRequest == value) return;
            signInRequest = value;
            OnPropertyChanged(nameof(SignInRequest));
        }
    }
    private SignInResponse signInResponse;
    public SignInResponse SignInResponse
    {
        get { return signInResponse; }
        set { OnPropertyChanged(nameof(SignInResponse)); }
    }

    public Command SignInCommand { get; set; }
    private async void SignInAsync()
    {
        var response = await UserService.SignInAsync(SignInRequest);
        if (response.IsSucceeded)
        {
            await SecureStorage.SetAsync("Token", response.JwtBearerToken);

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", response.JwtBearerToken);
            await Shell.Current.GoToAsync("//Tabs");
        }

        SignInRequest = new SignInRequest();
    }

    private async Task CheckIsUserSignedIn()
    {
        if (await SecureStorage.GetAsync("Token") is not null)
        {
            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", (await SecureStorage.GetAsync("Token")));
            await Shell.Current.GoToAsync("//Tabs");
        }
    }
}