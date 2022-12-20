using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Lecturer")]
public class LecturesController : ControllerBase
{
    public LecturesController(LecturesSevice lecturesService)
    {
        LecturesService = lecturesService;
    }

    private LecturesSevice LecturesService { get; }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddLectureAsync([FromBody] LectureEntity lecture)
    {
        var response = await LecturesService.AddLectureAsync(lecture);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateLectureAsync([FromBody] LectureEntity lecture)
    {
        var response = await LecturesService.UpdateLectureAsync(lecture);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{lectureId}")]
    public async Task<ActionResult<ActionResponse>> RemoveLectureAsync([FromRoute] int lectureId)
    {
        var response = await LecturesService.RemoveLectureAsync(lectureId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
