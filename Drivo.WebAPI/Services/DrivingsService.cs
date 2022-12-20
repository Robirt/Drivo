using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class DrivingsService
{
    public DrivingsService(DrivingsRepository drivingsRepository)
    {
        DrivingsRepository = drivingsRepository;
    }

    private DrivingsRepository DrivingsRepository { get; }

    public async Task<DrivingEntity> GetDrivingByIdAsync(int drivingId)
    {
        return await DrivingsRepository.GetDrivingByIdAsync(drivingId);
    }

    public async Task<ActionResponse> AddDrivingAsync(DrivingEntity driving)
    {
        return await DrivingsRepository.AddDrivingAsync(driving);
    }

    public async Task<ActionResponse> UpdateDrivingAsync(DrivingEntity driving)
    {
        return await DrivingsRepository.UpdateDrivingAsync(driving);
    }

    public async Task<ActionResponse> RemoveDrivingAsync(int drivingId)
    {
        return await DrivingsRepository.RemoveDrivingAsync(await GetDrivingByIdAsync(drivingId));
    }
}
