using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class InternalExamsRepository
{
    public InternalExamsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<InternalExamEntity>> GetInternalExamsByUserNameAsync(string userName)
    {
        return await Context.InternalExams.Where(driving => driving.Instructor.UserName == userName || driving.Student.UserName == userName).ToListAsync();
    }

    public async Task<InternalExamEntity> GetInternalExamByIdAsync(int internalExamId)
    {
        return await Context.InternalExams.FirstOrDefaultAsync(internalExam => internalExam.Id == internalExamId);
    }

    public async Task<ActionResponse> AddInternalExamAsync(InternalExamEntity internalExam)
    {
        try
        {
            await Context.InternalExams.AddAsync(internalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "InternalExam was added successfully.");
    }

    public async Task<ActionResponse> UpdateInternalExamAsync(InternalExamEntity internalExam)
    {
        try
        {
            Context.InternalExams.Update(internalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "InternalExam was updated successfully.");
    }

    public async Task<ActionResponse> RemoveInternalExamAsync(InternalExamEntity internalExam)
    {
        try
        {
            Context.InternalExams.Remove(internalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "InternalExam was removed successfully.");
    }
}
