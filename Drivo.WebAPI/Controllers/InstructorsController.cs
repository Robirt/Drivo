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
public class InstructorsController : ControllerBase
{
    public InstructorsController(InstructorsService instructorsService)
    {
        InstructorsService = instructorsService;
    }

    private InstructorsService InstructorsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<InstructorEntity>>> GetInstructors()
    {
        return Ok(await InstructorsService.GetInstructorsAsync());
    }

    [HttpGet("{userName}")]
    public async Task<ActionResult<InstructorEntity>> GetInstructorByUserName([FromRoute] string userName)
    {
        var instructor = await InstructorsService.GetInstructorByUserNameAsync(userName);

        return instructor is not null ? Ok(instructor) : NotFound(instructor);
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> CreateInstructor([FromBody] CreateUserRequest request)
    {
        var response = await InstructorsService.CreateInstructorAsync(request);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{userName}")]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> DeleteInstructor([FromRoute] string userName)
    {
        var response = await InstructorsService.DeleteInstructorAsync(userName);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
