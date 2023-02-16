using Drivo.Entities;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class LecturesService
{
    public LecturesService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; } 

    public async Task<List<LectureEntity>> GetLecturesAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<LectureEntity>>("/Lectures");
    }
}
