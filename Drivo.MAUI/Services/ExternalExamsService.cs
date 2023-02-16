using Drivo.Entities;
using Drivo.Responses;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class ExternalExamsService
{
    public ExternalExamsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<ExternalExamEntity>> GetExternalExamsAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<ExternalExamEntity>>("/ExternalsExams");
    }

    public async Task<ActionResponse> AddExternalExamsAsync(ExternalExamEntity externalExam)
    {
        return await (await HttpClient.PostAsJsonAsync("/ExternalExams", externalExam)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse> UpdateExternalExamsAsync(ExternalExamEntity externalExam)
    {
        return await (await HttpClient.PutAsJsonAsync("/ExternalExams", externalExam)).Content.ReadFromJsonAsync<ActionResponse>();
    }

    public async Task<ActionResponse> RemoveExternalExamsAsync(ExternalExamEntity externalExam)
    {
        return await (await HttpClient.DeleteAsync($"/ExternalExams/{externalExam.Id}")).Content.ReadFromJsonAsync<ActionResponse>();
    }
}
