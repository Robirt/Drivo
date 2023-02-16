using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Services;

public class StudentsService
{
    public StudentsService(UserManager<UserEntity> userManager, DatabaseContext context, MailsService mailsService, PasswordsService passwordService)
    {
        UserManager = userManager;
        Context = context;
        MailsService = mailsService;
        PasswordService = passwordService;
    }

    private UserManager<UserEntity> UserManager { get; }
    private DatabaseContext Context { get; }
    private MailsService MailsService { get; }
    private PasswordsService PasswordService { get; }

    public async Task<List<StudentEntity>> GetStudentsAsync()
    {
        return await UserManager.Users.OfType<StudentEntity>().ToListAsync();
    }

    public async Task<StudentEntity> GetStudentByUserNameAsync(string userName)
    {
        return await UserManager.Users.OfType<StudentEntity>().FirstOrDefaultAsync(user => user.UserName == userName);
    }

    public async Task<ActionResponse> CreateStudentAsync(CreateUserRequest request)
    {
        var userName = $"{request.FirstName}{request.LastName}";

        if ((await UserManager.Users.CountAsync(user => user.UserName.StartsWith(userName)) is var usersWithSameUserNameCount && usersWithSameUserNameCount > 0))
        {
            userName += $"{usersWithSameUserNameCount++}";
        }

        var password = PasswordService.GeneratePassword();

        if ((await UserManager.CreateAsync(new StudentEntity(userName, request.Email, request.FirstName, request.LastName, request.BirthDate, request.PhoneNumber), password) is var createResult && createResult.Succeeded == false))
        {
            return new ActionResponse(false, createResult.Errors.First().Description);
        }

        var student = await GetStudentByUserNameAsync(userName);

        if ((await UserManager.AddToRoleAsync(student, "Student")) is var addToRoleResult && addToRoleResult.Succeeded == false)
        {
            return new ActionResponse(false, addToRoleResult.Errors.First().Description);
        }

        if ((await MailsService.SendWelcomeMail(student, password)) is var sendWelcomeMailResult && sendWelcomeMailResult.IsSucceeded == false)
        {
            return sendWelcomeMailResult;
        }

        return new ActionResponse(true, "Student was created successfully.");
    }

    public async Task<ActionResponse> UpdateStudentAsync(StudentEntity student)
    {
        try
        {
            Context.Entry(student).State = EntityState.Modified;

            await Context.SaveChangesAsync();
        }

        catch (Exception exception)
        {
            return new ActionResponse(false, exception.Message ?? exception.InnerException?.Message ?? "An exception occured.");
        }

        return new ActionResponse(true, "Student was updated successfully.");
    }

    public async Task<ActionResponse> DeleteStudent(string userName)
    {
        var Student = await GetStudentByUserNameAsync(userName);

        if (Student == null)
        {
            return new ActionResponse(false, "Student was not found.");
        }

        if ((await UserManager.DeleteAsync(Student)) is var deleteResult && !deleteResult.Succeeded)
        {
            return new ActionResponse(false, deleteResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Student was deleted successfully.");
    }
}
