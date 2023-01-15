using Drivo.Entities;
using System.Net.Http.Json;

namespace Drivo.MAUI.Services;

public class CourseModulesService
{
    public CourseModulesService(HttpClient httpClient)
    {
        HttpClient = httpClient;
    }

    private HttpClient HttpClient { get; }

    public async Task<List<CourseModuleEntity>> GetCourseModulesAsync()
    {
        return await HttpClient.GetFromJsonAsync<List<CourseModuleEntity>>("/CourseModules");
    }

    public async Task<CourseModuleEntity> GetCourseModuleByNameAsync(string courseModuleName)
    {
        return await HttpClient.GetFromJsonAsync<CourseModuleEntity>($"/CourseModules/{courseModuleName}");
    }
}
