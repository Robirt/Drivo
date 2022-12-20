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
public class LecturersController : ControllerBase
{
    public LecturersController(LecturersService lecturersService)
    {
        LecturersService = lecturersService;
    }

    private LecturersService LecturersService { get; }

    [HttpGet]
    public async Task<ActionResult<List<LecturerEntity>>> GetLecturersAsync()
    {
        return Ok(await LecturersService.GetLecturersAsync());
    }

    [HttpGet("{lecturerUserName}")]
    public async Task<ActionResult<LecturerEntity>> GetLecturerByUserNameAsync([FromRoute] string lecturerUserName)
    {
        var lecturer = await LecturersService.GetLecturerByUserNameAsync(lecturerUserName);

        return lecturer is not null ? Ok(lecturer) : BadRequest();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> CreateLecturerAsync(CreateUserRequest request)
    {
        var response = await LecturersService.CreateLecturerAsync(request);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    [Authorize(Roles = "Administrator")]
    public async Task<ActionResult<ActionResponse>> DeleteLecturerAsync(string lecturerUserName)
    {
        var response = await LecturersService.DeleteLecturerAsync(lecturerUserName);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
