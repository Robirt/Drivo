using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class ResourcesRepository
{
    public ResourcesRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<ResourceEntity> GetResourceByIdAsync(int resourceId)
    {
        return await Context.Resources.FirstOrDefaultAsync(resource => resource.Id == resourceId);
    }

    public async Task<ActionResponse> AddResourceAsync(ResourceEntity resource)
    {
        try
        {
            await Context.Resources.AddAsync(resource);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Resource was added successfully.");
    }

    public async Task<ActionResponse> UpdateResourceAsync(ResourceEntity resource)
    {
        try
        {
            Context.Resources.Update(resource);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Resource was updated successfully.");
    }

    public async Task<ActionResponse> RemoveResourceAsync(ResourceEntity resource)
    {
        try
        {
            Context.Resources.Remove(resource);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Resource was removed successfully.");
    }
}
