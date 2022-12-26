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
public class CourseModulesControllers : ControllerBase
{
    public CourseModulesControllers(CourseModulesService courseModulesService)
    {
        CourseModulesService = courseModulesService;
    }

    private CourseModulesService CourseModulesService { get; }

    [HttpGet]
    public async Task<ActionResult<List<CourseModuleEntity>>> GetCourseModulesAsync()
    {
        return Ok(await CourseModulesService.GetCourseModulesAsync());
    }

    [HttpGet("{courseModulename}")]
    public async Task<ActionResult<CourseModuleEntity>> GetCourseModuleByNameAsync([FromRoute] string courseModulename)
    {
        var courseModule = await CourseModulesService.GetCourseModuleByNameAsync(courseModulename);

        return courseModule is not null ? Ok(courseModule) : BadRequest();
    }

    [HttpPost]
    [Authorize(Roles = "Administrator, Lecturer")]
    public async Task<ActionResult<ActionResponse>> AddCourseModuleAsync([FromBody] CourseModuleEntity courseModule)
    {
        var response = await CourseModulesService.AddCourseModuleAsync(courseModule);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut("{courseModuleName}")]
    [Authorize(Roles = "Administrator, Lecturer")]
    public async Task<ActionResult<ActionResponse>> UpdateCourseModuleAsync([FromBody] CourseModuleEntity courseModule)
    {
        var response = await CourseModulesService.UpdateCourseModuleAsync(courseModule);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{courseModulename}")]
    [Authorize(Roles = "Administrator, Lecturer")]
    public async Task<ActionResult<ActionResponse>> RemoveCourseModuleAsync([FromRoute] string courseModuleName)
    {
        var response = await CourseModulesService.RemoveCourseModuleAsync(courseModuleName);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}