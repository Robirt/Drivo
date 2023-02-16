using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
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

    [HttpGet]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public async Task<UserEntity> GetUserAsync()
    {
        return await UsersService.GetUserByUserName(User.Identity.Name);
    }

    [HttpPost("SignIn")]
    public async Task<ActionResult<SignInResponse>> SignInAsync(SignInRequest request)
    {
        return await UsersService.SignInAsync(request);
    }
}
