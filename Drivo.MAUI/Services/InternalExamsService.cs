using Drivo.Entities;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class InternalExamsService
{
    public InternalExamsService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<InternalExamEntity>> GetInternalExamsAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<InternalExamEntity>>("/InternalExams");
    }
}
