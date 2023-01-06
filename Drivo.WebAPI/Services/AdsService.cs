using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Repositories;

namespace Drivo.WebAPI.Services;

public class AdsService
{
    public AdsService(AdsRepository adsRepository)
    {
        AdsRepository = adsRepository;
    }

    private AdsRepository AdsRepository { get; }

    public async Task<List<AdEntity>> GetAdsAsync()
    {
        return await AdsRepository.GetAdsAsync();
    }

    public async Task<AdEntity> GetAdById(int adId)
    {
        return await AdsRepository.GetAdById(adId);
    }

    public async Task<ActionResponse> AddAdAsync(AdEntity ad)
    {
        ad.Date = DateTime.Now;

        return await AdsRepository.AddAdAsync(ad);
    }

    public async Task<ActionResponse> UpdateAdAsync(AdEntity ad)
    {
        return await AdsRepository.UpdateAdAsync(ad);
    }

    public async Task<ActionResponse> RemoveAdAsync(int adId)
    {
        var ad = await AdsRepository.GetAdById(adId);

        if (ad is null)
        {
            return new ActionResponse(false, "Ad was not found");
        }

        return await AdsRepository.RemoveAdAsync(ad);
    }
}
