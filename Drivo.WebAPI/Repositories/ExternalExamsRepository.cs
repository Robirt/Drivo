using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class ExternalExamsRepository
{
    public ExternalExamsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<ExternalExamEntity> GetExternalExamById(int externalExamId)
    {
        return await Context.ExternalExams.FirstOrDefaultAsync(externalExam => externalExam.Id == externalExamId);
    }

    public async Task<List<ExternalExamEntity>> GetExternalExamsByStudentAsync(StudentEntity student)
    {
        return await Context.ExternalExams.Where(externalExam => externalExam.StudentId == student.Id).ToListAsync();
    }

    public async Task<ActionResponse> AddExternalExamAsync(ExternalExamEntity externalExam)
    {
        try
        {
            await Context.ExternalExams.AddAsync(externalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "External Exam was added successfully.");
    }

    public async Task<ActionResponse> UpdateExternalExamAsync(ExternalExamEntity externalExam)
    {
        try
        {
            Context.ExternalExams.Update(externalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "External Exam was updated successfully.");
    }

    public async Task<ActionResponse> RemoveExternalExamAsync(ExternalExamEntity externalExam)
    {
        try
        {
            Context.ExternalExams.Remove(externalExam);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "External Exam was removed successfully.");
    }
}
