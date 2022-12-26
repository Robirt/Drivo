using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers
{
    [ApiController]
    [Route("[Controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class StudentsController : ControllerBase
    {
        public StudentsController(StudentsService studentsService)
        {
            StudentsService = studentsService;
        }

        private StudentsService StudentsService { get; }

        [HttpGet]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<List<StudentEntity>>> GetStudentsAsync()
        {
            return Ok(await StudentsService.GetStudentsAsync());
        }

        [HttpGet("{userName}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<StudentEntity>> GetStudentByUserNameAsync([FromRoute] string userName)
        {
            var student = await StudentsService.GetStudentByUserNameAsync(userName);

            return student is not null ? Ok(student) : BadRequest();
        }

        [HttpPost]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ActionResponse>> CreateStudentAsync([FromBody] CreateUserRequest request)
        {
            var response = await StudentsService.CreateStudentAsync(request);

            return response.IsSucceeded ? Ok(response) : BadRequest(response);
        }

        [HttpDelete("{userName}")]
        [Authorize(Roles = "Administrator")]
        public async Task<ActionResult<ActionResponse>> DeleteStudentAsync([FromRoute] string userName)
        {
            var response = await StudentsService.DeleteStudent(userName);

            return response.IsSucceeded ? Ok(response) : BadRequest(response);
        }
    }
}
