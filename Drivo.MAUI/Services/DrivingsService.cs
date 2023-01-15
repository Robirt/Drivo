using Drivo.Entities;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class DrivingsService
{
    public DrivingsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<DrivingEntity>> GetDrivingsAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<DrivingEntity>>("/Drivings");
    }
}
