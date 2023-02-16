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
public class DrivingsController : ControllerBase
{
    public DrivingsController(DrivingsService drivingsService)
    {
        DrivingsService = drivingsService;
    }

    private DrivingsService DrivingsService { get; }

    [HttpGet]
    [Authorize(Roles = "Instructor, Student")]
    public async Task<List<DrivingEntity>> GetDrivingsByUserNameAsync()
    {
        return await DrivingsService.GetDrivingsByUserNameAsync(User.Identity.Name);
    }

    [HttpPost]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> AddDrivingAsync([FromBody] DrivingEntity driving)
    {
        var response = await DrivingsService.AddDrivingAsync(driving);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> UpdateDrivingAsync([FromBody] DrivingEntity driving)
    {
        var response = await DrivingsService.UpdateDrivingAsync(driving);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{drivingId}")]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> RemoveDrivingAsync([FromRoute] int drivingId)
    {
        var response = await DrivingsService.RemoveDrivingAsync(drivingId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
