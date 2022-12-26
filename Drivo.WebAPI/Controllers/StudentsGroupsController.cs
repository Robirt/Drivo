using Drivo.Entities;
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
    public async Task<ActionResult<List<StudentsGroupEntity>>> GetStudentsGroups()
    {
        return Ok(await StudentsGroupsService.GetStudentsGroupsAsync());
    }
}
