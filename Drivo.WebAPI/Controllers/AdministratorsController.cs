using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class AdministratorsController : ControllerBase
{
    public AdministratorsController(AdministratorsService administratorsService)
    {
        AdministratorsService = administratorsService;
    }

    private AdministratorsService AdministratorsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<AdministratorEntity>>> GetAdministrators()
    {
        return Ok(await AdministratorsService.GetAdministratorsAsync());
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<AdministratorEntity>> GetAdministratorByUserNameAsync([FromRoute] string userName)
    {
        var administrator = await AdministratorsService.GetAdministratorByUserNameAsync(userName);

        return administrator is not null ? Ok(administrator) : NotFound(administrator);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> CreateAdministratorAsync([FromBody] CreateUserRequest request)
    {
        var response = await AdministratorsService.CreateAdministratorAsync(request);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> UpdateAdministratorAsync([FromBody] AdministratorEntity administrator)
    {
        var response = await AdministratorsService.UpdateAdministratorAsync(administrator);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{userName}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> DeleteAdministratorAsync([FromRoute] string userName)
    {
        var response = await AdministratorsService.DeleteAdministratorAsync(userName);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
