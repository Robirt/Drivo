using Drivo.Entities;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
public class StudentsGroupsController : ControllerBase
{
    public StudentsGroupsController(StudentsGroupsService studentsGroupsService)
    {
        StudentsGroupsService = studentsGroupsService;
    }

    private StudentsGroupsService StudentsGroupsService { get; }

    public async Task<ActionResult<List<StudentsGroupEntity>>> GetStudentsGroups()
    {
        return Ok(await StudentsGroupsService.GetStudentsGroupsAsync());
    }
}
