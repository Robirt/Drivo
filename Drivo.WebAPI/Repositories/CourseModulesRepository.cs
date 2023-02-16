using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class CourseModulesRepository
{
    public CourseModulesRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<CourseModuleEntity>> GetCourseModulesAsync()
    {
        return await Context.CourseModules.ToListAsync();
    }

    public async Task<CourseModuleEntity> GetCourseModuleByNameAsync(string courseModuleName)
    {
        return await Context.CourseModules.FirstOrDefaultAsync(courseModule => courseModule.Name == courseModuleName);
    }

    public async Task<ActionResponse> AddCourseModuleAsync(CourseModuleEntity courseModule)
    {
        try
        {
            await Context.CourseModules.AddAsync(courseModule);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Course module was added successfully.");
    }

    public async Task<ActionResponse> UpdateCourseModuleAsync(CourseModuleEntity courseModule)
    {
        try
        {
            Context.CourseModules.Update(courseModule);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Course module was updated successfully.");
    }

    public async Task<ActionResponse> RemoveCourseModuleAsync(CourseModuleEntity courseModule)
    {
        try
        {
            Context.CourseModules.Remove(courseModule);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Course module was removed successfully.");
    }
}
