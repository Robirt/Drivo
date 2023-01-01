using Drivo.Entities;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class AdsService
{
    public AdsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<AdEntity>> GetAdsAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<AdEntity>>("/Ads");
    }

    public async Task<ActionResponse> GetAdByIdAsync(int adId)
    {
        return await HttpClient.GetFromJsonAsync<ActionResponse>($"/Ads/{adId}");
    }
}
