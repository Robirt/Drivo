using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class ResourcesService
{
    public ResourcesService(ResourcesRepository resourcesRepository)
    {
        ResourcesRepository = resourcesRepository;
    }

    private ResourcesRepository ResourcesRepository { get; }

    public async Task<ResourceEntity> GetResourceByIdAsync(int resourceId)
    {
        return await ResourcesRepository.GetResourceByIdAsync(resourceId);
    }

    public async Task<ActionResponse> AddResourceAsync(ResourceEntity resource)
    {
        return await ResourcesRepository.UpdateResourceAsync(resource);
    }

    public async Task<ActionResponse> UpdateResourceAsync(ResourceEntity resource)
    {
        return await ResourcesRepository.UpdateResourceAsync(resource);
    }

    public async Task<ActionResponse> RemoveResourceAsync(int resourceId)
    {
        return await ResourcesRepository.RemoveResourceAsync(await GetResourceByIdAsync(resourceId));
    }
}
