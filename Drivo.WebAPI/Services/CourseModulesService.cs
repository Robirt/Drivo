using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class CourseModulesService
{
    public CourseModulesService(CourseModulesRepository courseModulesRepository)
    {
        CourseModulesRepository = courseModulesRepository;
    }

    private CourseModulesRepository CourseModulesRepository { get; }

    public async Task<List<CourseModuleEntity>> GetCourseModulesAsync()
    {
        return await CourseModulesRepository.GetCourseModulesAsync();
    }

    public async Task<CourseModuleEntity> GetCourseModuleByNameAsync(string courseModuleName)
    {
        return await CourseModulesRepository.GetCourseModuleByNameAsync(courseModuleName);
    }

    public async Task<ActionResponse> AddCourseModuleAsync(CourseModuleEntity courseModule)
    {
        return await CourseModulesRepository.AddCourseModuleAsync(courseModule);
    }

    public async Task<ActionResponse> UpdateCourseModuleAsync(CourseModuleEntity courseModule)
    {
        return await CourseModulesRepository.UpdateCourseModuleAsync(courseModule);
    }

    public async Task<ActionResponse> RemoveCourseModuleAsync(string courseModuleName)
    {
        var courseModule = await CourseModulesRepository.GetCourseModuleByNameAsync(courseModuleName);

        if (courseModule is null) return new ActionResponse(false, "Course module was not found");

        return await CourseModulesRepository.RemoveCourseModuleAsync(courseModule);
    }
}
