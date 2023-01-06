using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Services;

public class InstructorsService
{
    public InstructorsService(UserManager<UserEntity> userManager, MailsService mailsService, PasswordsService passwordService)
    {
        UserManager = userManager;
        MailsService = mailsService;
        PasswordService = passwordService;
    }

    private UserManager<UserEntity> UserManager { get; }
    private MailsService MailsService { get; }
    private PasswordsService PasswordService { get; }

    public async Task<List<InstructorEntity>> GetInstructorsAsync()
    {
        return await UserManager.Users.OfType<InstructorEntity>().ToListAsync();
    }

    public async Task<InstructorEntity> GetInstructorByUserNameAsync(string userName)
    {
        return await UserManager.Users.OfType<InstructorEntity>().FirstOrDefaultAsync(user => user.UserName == userName);
    }

    public async Task<ActionResponse> CreateInstructorAsync(CreateUserRequest request)
    {
        var userName = $"{request.FirstName}{request.LastName}";

        if ((await UserManager.Users.CountAsync(user => user.UserName.StartsWith(userName)) is var usersWithSameUserNameCount && usersWithSameUserNameCount > 0))
        {
            userName += $"{usersWithSameUserNameCount++}";
        }

        var password = PasswordService.GeneratePassword();

        if ((await UserManager.CreateAsync(new InstructorEntity(userName, request.Email, request.FirstName, request.LastName, request.BirthDate, request.PhoneNumber), password) is var createResult && createResult.Succeeded == false))
        {
            return new ActionResponse(false, createResult.Errors.First().Description);
        }

        var instructor = await GetInstructorByUserNameAsync(userName);

        if ((await UserManager.AddToRoleAsync(instructor, "Instructor")) is var addToRoleResult && addToRoleResult.Succeeded == false)
        {
            return new ActionResponse(false, addToRoleResult.Errors.First().Description);
        }

        if ((await MailsService.SendWelcomeMail(instructor, password)) is var sendWelcomeMailResult && sendWelcomeMailResult.IsSucceeded == false)
        {
            return sendWelcomeMailResult;
        }

        return new ActionResponse(true, "Instructor was created successfully.");
    }

    public async Task<ActionResponse> DeleteInstructorAsync(string userName)
    {
        var instructor = await GetInstructorByUserNameAsync(userName);

        if (instructor == null)
        {
            return new ActionResponse(false, "Instructor was not found.");
        }

        if ((await UserManager.DeleteAsync(instructor)) is var deleteResult && !deleteResult.Succeeded)
        {
            return new ActionResponse(false, deleteResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Instructor was deleted successfully.");
    }
}
