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
        SignInCommand = new Command(SignIn);
    }

    private SignInRequest signInRequest;

    private UserService UserService { get; }

    private HttpClient HttpClient { get; }
    public SignInRequest SignInRequest
    {
        get { return signInRequest; }
        set { OnPropertyChanged(nameof(SignInRequest)); }
    }
    private SignInResponse signInResponse;
    public SignInResponse SignInResponse
    {
        get { return signInResponse; }
        set { OnPropertyChanged(nameof(SignInResponse)); }
    }

    public Command SignInCommand { get; set; }
    private async void SignIn()
    {
        var Response = await UserService.SignInAsync(SignInRequest);
        if (Response.IsSucceeded)
        {
            await SecureStorage.SetAsync("Token", Response.JwtBearerToken);

            HttpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Response.JwtBearerToken);
            await Shell.Current.GoToAsync("//HomePage");
        }
        else
        {

        }

        SignInRequest = new SignInRequest();
    }


}