using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class DrivingsRepository
{
    public DrivingsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<DrivingEntity>> GetDrivingsByUserAsync(string userName)
    {
        return await Context.Drivings.Where(driving => driving.Instructor.UserName == userName || driving.Student.UserName == userName).ToListAsync();
    }

    public async Task<DrivingEntity> GetDrivingByIdAsync(int drivingId)
    {
        return await Context.Drivings.FirstOrDefaultAsync(driving => driving.Id == drivingId);
    }

    public async Task<ActionResponse> AddDrivingAsync(DrivingEntity driving)
    {
        try
        {
            await Context.Drivings.AddAsync(driving);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Driving was added successfully.");
    }

    public async Task<ActionResponse> UpdateDrivingAsync(DrivingEntity driving)
    {
        try
        {
            Context.Drivings.Update(driving);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Driving was updated successfully.");
    }

    public async Task<ActionResponse> RemoveDrivingAsync(DrivingEntity driving)
    {
        try
        {
            Context.Drivings.Remove(driving);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Driving was removed successfully.");
    }
}
