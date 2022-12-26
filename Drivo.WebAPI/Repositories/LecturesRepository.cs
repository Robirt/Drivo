using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class LecturesRepository
{
    public LecturesRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<LectureEntity>> GetLecturesByUserName(string userName)
    {
        return await Context.Lectures.Where(driving => driving.Lecturer.UserName == userName || driving.StudentsGroup.Students.Select(student => student.UserName).Contains(userName)).ToListAsync();
    }

    public async Task<LectureEntity> GetLectureByIdAsync(int lectureId)
    {
        return await Context.Lectures.FirstOrDefaultAsync(lecture => lecture.Id == lectureId);
    }

    public async Task<ActionResponse> AddLectureAsync(LectureEntity lecture)
    {
        try
        {
            await Context.Lectures.AddAsync(lecture);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "Lecture was added successfully.");
    }

    public async Task<ActionResponse> UpdateLectureAsync(LectureEntity lecture)
    {
        try
        {
            Context.Lectures.Update(lecture);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "Lecture was updated successfully.");
    }

    public async Task<ActionResponse> RemoveLectureAsync(LectureEntity lecture)
    {
        try
        {
            Context.Lectures.Remove(lecture);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message);
        }

        return new ActionResponse(true, "Lecture was removed successfully.");
    }
}
