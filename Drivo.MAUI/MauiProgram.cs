using Microsoft.Extensions.Configuration;

namespace Drivo.MAUI;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder.UseMauiApp<App>();

        builder.Services.AddViews();

        builder.Services.AddViewModels();

        builder.Services.AddScoped(httpClient => new HttpClient() { BaseAddress = new Uri("https://localhost:5001")});

        builder.Services.AddServices();
       
        return builder.Build();
    }
}