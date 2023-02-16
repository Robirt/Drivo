using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;

namespace Drivo.WebAPI.Services;

public class UsersService
{
    public UsersService(UserManager<UserEntity> userManager, JwtBearerTokensService jwtBearerTokenService)
    {
        UserManager = userManager;
        JwtBearerTokenService = jwtBearerTokenService;
    }

    private UserManager<UserEntity> UserManager { get; }
    private JwtBearerTokensService JwtBearerTokenService { get; }

    public async Task<UserEntity> GetUserByUserName(string userName)
    {
        return await UserManager.FindByNameAsync(userName);
    }

    public async Task<string> GetRoleNameByUserName(string userName)
    {
        return (await UserManager.GetRolesAsync(await GetUserByUserName(userName))).First();
    }

    public async Task<SignInResponse> SignInAsync(SignInRequest request)
    {
        var user = await UserManager.FindByNameAsync(request.UserName);

        if (user is null) return new SignInResponse(false, "User does not exist.");

        if (await UserManager.CheckPasswordAsync(await GetUserByUserName(request.UserName), request.Password))
        {
            return new SignInResponse(true, "User successfully logged in.") { JwtBearerToken = JwtBearerTokenService.GetToken(request.UserName, await GetRoleNameByUserName(request.UserName)) };
        }

        else return new SignInResponse(false, "Wrong Name or Password");
    }
}
