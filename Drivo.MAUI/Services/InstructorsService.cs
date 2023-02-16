using Drivo.Entities;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class InstructorsService
{
    public InstructorsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<InstructorEntity>> GetInstructorsAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<InstructorEntity>>("/Instructors");
    }

    public async Task<ActionResponse> GetInstructorByUserNameAsync(string userName)
    {
        return await HttpClient.GetFromJsonAsync<ActionResponse>($"/Instructors/{userName}");
    }
}
