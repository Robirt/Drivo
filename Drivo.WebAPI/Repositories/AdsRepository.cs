using Drivo.Entities;
using Drivo.Responses;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Repositories;

public class AdsRepository
{
    public AdsRepository(DatabaseContext context)
    {
        Context = context;
    }

    private DatabaseContext Context { get; }

    public async Task<List<AdEntity>> GetAdsAsync()
    {
        return await Context.Ads.ToListAsync();
    }

    public async Task<AdEntity> GetAdById(int adId)
    {
        return await Context.Ads.FirstOrDefaultAsync(ad => ad.Id == adId);
    }

    public async Task<ActionResponse> AddAdAsync(AdEntity ad)
    {
        try
        {
            await Context.Ads.AddAsync(ad);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Ad was added successfully.");
    }

    public async Task<ActionResponse> UpdateAdAsync(AdEntity ad)
    {
        try
        {
            Context.Ads.Update(ad);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Ad was updated successfully.");
    }

    public async Task<ActionResponse> RemoveAdAsync(AdEntity ad)
    {
        try
        {
            Context.Ads.Remove(ad);

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Ad was removed successfully.");
    }
}
