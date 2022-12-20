using Drivo.Entities;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[ApiController]
[Route("[Controller]")]
[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Student")]
public class ExternalExamsController : ControllerBase
{
    public ExternalExamsController(ExternalExamsService externalExamsService)
    {
        ExternalExamsService = externalExamsService;
    }

    private ExternalExamsService ExternalExamsService { get; }

    [HttpGet]
    public async Task<ActionResult<List<ExternalExamEntity>>> GetExternalExamsAsync()
    {
        var externalExams = await ExternalExamsService.GetExternalExamsByStudentAsync(User.Identity.Name);

        return externalExams.Any() ? Ok(externalExams) : NotFound();
    }

    [HttpPost]
    public async Task<ActionResult<ActionResponse>> AddExternalExamAsync([FromBody] ExternalExamEntity externalExam)
    {
        var response = await ExternalExamsService.AddExternalExamAsync(externalExam, User.Identity.Name);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    public async Task<ActionResult<ActionResponse>> UpdateExternalExamAsync([FromBody] ExternalExamEntity externalExam)
    {
        var response = await ExternalExamsService.UpdateExternalExamAsync(externalExam, User.Identity.Name);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete]
    public async Task<ActionResult<ActionResponse>> RemoveExternalExamAsync([FromRoute] int externalExamId)
    {
        var response = await ExternalExamsService.RemoveExternalExamAsync(externalExamId, User.Identity.Name);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
