namespace Drivo.WebAPI.Services;

public class BackgroundNotificationsService : BackgroundService
{
    public BackgroundNotificationsService(IServiceProvider serviceProvider)
    {
        ServiceProvider = serviceProvider;
    }

    private IServiceProvider ServiceProvider { get; }

    protected async override Task ExecuteAsync(CancellationToken stoppingToken)
    {

    }
}
