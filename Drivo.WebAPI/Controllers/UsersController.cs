using Drivo.Requests;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace Drivo.WebAPI.Controllers;

[Route("[Controller]")]
[ApiController]
public class UsersController : ControllerBase
{
    public UsersController(UsersService usersService)
    {
        UsersService = usersService;
    }

    private UsersService UsersService { get; }

    [HttpPost("SignIn")]
    public async Task<ActionResult<SignInResponse>> SignInAsync(SignInRequest request)
    {
        return await UsersService.SignInAsync(request);
    }
}
