using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AdsController : ControllerBase
{
    public AdsController(AdsService adsService)
    {
        AdsService = adsService;
    }

    private AdsService AdsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<AdEntity>>> GetAdsAsync()
    {
        return Ok(await AdsService.GetAdsAsync());
    }

    [HttpGet("{adId}")]
    public async Task<ActionResult<AdEntity>> GetAdByIdAsync([FromRoute] int adId)
    {
        var ad = await AdsService.GetAdById(adId);

        return ad is not null ? Ok(ad) : BadRequest();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> AddAdAsync([FromBody] AdEntity ad)
    {
        var response = await AdsService.AddAdAsync(ad);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> UpdateAdAsync([FromBody] AdEntity ad)
    {
        var response = await AdsService.UpdateAdAsync(ad);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{adId}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> RemoveAdAsync([FromRoute] int adId)
    {
        var response = await AdsService.RemoveAdAsync(adId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
