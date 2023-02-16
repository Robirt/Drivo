using Drivo.Entities;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class LecturersService
{
    public LecturersService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<LecturerEntity>> GetLecturersAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<LecturerEntity>>("/Lecturers");
    }

    public async Task<ActionResponse> GetLecturerByUserNameAsync(string userName)
    {
        return await HttpClient.GetFromJsonAsync<ActionResponse>($"/Lecturers/{userName}");
    }
}
