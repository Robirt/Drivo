using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")]
public class ResourcesController : ControllerBase
{
    public ResourcesController(ResourcesService resourcesService)
    {
        ResourcesService = resourcesService;
    }

    private ResourcesService ResourcesService { get; }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddResourceAsync([FromBody] ResourceEntity resource)
    {
        var response = await ResourcesService.AddResourceAsync(resource);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateResourceAsync([FromBody] ResourceEntity resource)
    {
        var response = await ResourcesService.UpdateResourceAsync(resource);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{resourceId}")]
    public async Task<ActionResult<ActionResponse>> RemoveResourceAsync([FromRoute] int resourceId)
    {
        var response = await ResourcesService.RemoveResourceAsync(resourceId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}