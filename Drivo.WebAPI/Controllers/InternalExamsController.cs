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
public class InternalExamsController : ControllerBase
{
    public InternalExamsController(InternalExamsService internalExamsService)
    {
        InternalExamsService = internalExamsService;
    }

    private InternalExamsService InternalExamsService { get; }

    [HttpGet]
    [Authorize(Roles = "Instructor, Student")]
    public async Task<List<InternalExamEntity>> GetInternalExamsByUserNameAsync()
    {
        return await InternalExamsService.GetInternalExamsByUserName(User.Identity.Name);
    }

    [HttpPost]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> AddInternalExamAsync([FromBody] InternalExamEntity internalExam)
    {
        var response = await InternalExamsService.AddInternalExamAsync(internalExam);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpPut]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> UpdateInternalExamAsync([FromBody] InternalExamEntity internalExam)
    {
        var response = await InternalExamsService.UpdateInternalExamAsync(internalExam);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }

    [HttpDelete("{internalExamId}")]
    [Authorize(Roles = "Instructor")]
    public async Task<ActionResult<ActionResponse>> RemoveInternalExamAsync([FromRoute] int internalExamId)
    {
        var response = await InternalExamsService.RemoveInternalExamAsync(internalExamId);

        return response.IsSucceeded ? Ok(response) : BadRequest(response);
    }
}
