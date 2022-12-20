using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class StudentsGroupsRepository
{
    public StudentsGroupsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<StudentsGroupEntity>> GetStudentsGroupsAsync()
    {
        return await Context.StudentsGroups.ToListAsync();
    }

    public async Task<ActionResponse> AddStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        try
        {
            await Context.StudentsGroups.AddAsync(studentsGroup);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Student group was added successfully.");
    }

    public async Task<ActionResponse> UpdateStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        try
        {
            Context.StudentsGroups.Update(studentsGroup);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Student group was updated successfully.");
    }

    public async Task<ActionResponse> RemoveStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        try
        {
            Context.StudentsGroups.Remove(studentsGroup);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Student group was added successfully.");
    }
}
