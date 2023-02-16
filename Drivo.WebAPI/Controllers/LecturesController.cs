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
public class LecturesController : ControllerBase
{
    public LecturesController(LecturesSevice lecturesService)
    {
        LecturesService = lecturesService;
    }

    private LecturesSevice LecturesService { get; }

    [HttpGet]
    [Authorize(Roles = "Lecturer, Student")]
    public async Task<List<LectureEntity>> GetLecturesByUserNameAsync()
    {
        return await LecturesService.GetLecturesByUserName(User.Identity.Name);
    }

    [HttpPost]
    [Authorize(Roles = "Lecturer")]
    public async Task<ActionResult<ActionResponse>> AddLectureAsync([FromBody] LectureEntity lecture)
    {
        var response = await LecturesService.AddLectureAsync(lecture);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Lecturer")]
    public async Task<ActionResult<ActionResponse>> UpdateLectureAsync([FromBody] LectureEntity lecture)
    {
        var response = await LecturesService.UpdateLectureAsync(lecture);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{lectureId}")]
    [Authorize(Roles = "Lecturer")]
    public async Task<ActionResult<ActionResponse>> RemoveLectureAsync([FromRoute] int lectureId)
    {
        var response = await LecturesService.RemoveLectureAsync(lectureId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
