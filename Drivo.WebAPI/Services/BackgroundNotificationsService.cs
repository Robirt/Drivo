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
        using (PeriodicTimer timer = new PeriodicTimer(TimeSpan.FromDays(1)))
        {
            while (!stoppingToken.IsCancellationRequested && await timer.WaitForNextTickAsync(stoppingToken))
            {
                using (IServiceScope serviceScope = ServiceProvider.CreateAsyncScope())
                {

                }
            }
        }
    }
}
