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
public class StudentsGroupsController : ControllerBase
{
    public StudentsGroupsController(StudentsGroupsService studentsGroupsService)
    {
        StudentsGroupsService = studentsGroupsService;
    }

    private StudentsGroupsService StudentsGroupsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<StudentsGroupEntity>>> GetStudentsGroupsAsync()
    {
        return Ok(await StudentsGroupsService.GetStudentsGroupsAsync());
    }

    [HttpGet("{studentsGroupId}")]
    public async Task<ActionResult<StudentsGroupEntity>> GetStudentsGroupByIdAsync(int studentsGroupId)
    {
        var studentsGroup = await StudentsGroupsService.GetStudentsGroupByIdAsync(studentsGroupId);

        return studentsGroup is not null ? Ok(studentsGroup) : BadRequest();
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        var response = await StudentsGroupsService.AddStudentsGroupAsync(studentsGroup);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateStudentsGroupAsync(StudentsGroupEntity studentsGroup)
    {
        var response = await StudentsGroupsService.UpdateStudentsGroupAsync(studentsGroup);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{studentsGroupId}")]
    public async Task<ActionResult<ActionResponse>> RemoveStudentsGroupAsyncAsync([FromRoute] int studentsGroupId)
    {
        var response = await StudentsGroupsService.RemoveStudentsGroupAsync(studentsGroupId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
