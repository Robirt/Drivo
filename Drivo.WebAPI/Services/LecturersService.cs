using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Services;

public class LecturersService
{
    public LecturersService(UserManager<UserEntity> userManager, MailsService mailsService, PasswordService passwordService)
    {
        UserManager = userManager;
        MailsService = mailsService;
        PasswordService = passwordService;
    }

    private UserManager<UserEntity> UserManager { get; }
    private MailsService MailsService { get; }
    private PasswordService PasswordService { get; }

    public async Task<List<LecturerEntity>> GetLecturersAsync()
    {
        return await UserManager.Users.OfType<LecturerEntity>().ToListAsync();
    }

    public async Task<LecturerEntity> GetLecturerByUserNameAsync(string lecturerUserName)
    {
        return await UserManager.Users.OfType<LecturerEntity>().SingleOrDefaultAsync(user => user.UserName == lecturerUserName);
    }

    public async Task<ActionResponse> CreateLecturerAsync(CreateUserRequest request)
    {
        var userName = $"{request.FirstName}{request.LastName}";

        if ((await UserManager.Users.CountAsync(user => user.UserName.StartsWith(userName)) is var usersWithSameUserNameCount && usersWithSameUserNameCount > 0))
        {
            userName += $"{usersWithSameUserNameCount++}";
        }

        var password = PasswordService.GeneratePassword();

        if ((await UserManager.CreateAsync(new LecturerEntity(userName, request.Email, request.FirstName, request.LastName, request.BirthDate), password) is var createResult && createResult.Succeeded == false))
        {
            return new ActionResponse(false, createResult.Errors.First().Description);
        }

        var lecturer = await GetLecturerByUserNameAsync(userName);

        if ((await UserManager.AddToRoleAsync(lecturer, "Lecturer")) is var addToRoleResult && addToRoleResult.Succeeded == false)
        {
            return new ActionResponse(false, addToRoleResult.Errors.First().Description);
        }

        if ((await MailsService.SendWelcomeMail(lecturer, password)) is var sendWelcomeMailResult && sendWelcomeMailResult.IsSucceeded == false)
        {
            return sendWelcomeMailResult;
        }

        return new ActionResponse(true, "Lecturer was created successfully.");
    }

    public async Task<ActionResponse> DeleteLecturerAsync(string lecturerUserName)
    {
        var lecturer = await GetLecturerByUserNameAsync(lecturerUserName);

        if (lecturer == null)
        {
            return new ActionResponse(false, "Lecturer was not found.");
        }

        if ((await UserManager.DeleteAsync(lecturer)) is var deleteResult && !deleteResult.Succeeded)
        {
            return new ActionResponse(false, deleteResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Lecturer was deleted successfully.");
    }
}
