using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Services;

public class StudentsService
{
    public StudentsService(UserManager<UserEntity> userManager)
    {
        UserManager = userManager;
    }

    private UserManager<UserEntity> UserManager { get; }

    public async Task<List<StudentEntity>> GetStudentsAsync()
    {
        return await UserManager.Users.OfType<StudentEntity>().ToListAsync();
    }

    public async Task<StudentEntity> GetStudentByUserNameAsync(string userName)
    {
        return await UserManager.Users.OfType<StudentEntity>().SingleAsync(user => user.UserName == userName);
    }

    public async Task<ActionResponse> CreateStudentAsync(CreateUserRequest request)
    {
        var userName = $"{request.FirstName}{request.LastName}";

        if ((await UserManager.Users.CountAsync(user => user.UserName.StartsWith(userName)) is var usersWithSameUserNameCount && usersWithSameUserNameCount > 0))
        {
            userName += $"{usersWithSameUserNameCount++}";
        }

        if ((await UserManager.CreateAsync(new AdministratorEntity(userName, request.Email, request.FirstName, request.LastName, request.BirthDate)) is var createResult && createResult.Succeeded == false))
        {
            return new ActionResponse(false, createResult.Errors.First().Description);
        }

        var student = await GetStudentByUserNameAsync(userName);

        if ((await UserManager.AddToRoleAsync(student, "Student")) is var addToRoleResult && addToRoleResult.Succeeded == false)
        {
            return new ActionResponse(false, addToRoleResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Student was created successfully.");
    }

    public async Task<ActionResponse> DeleteStudent(string userName)
    {
        var administrator = await GetStudentByUserNameAsync(userName);

        if (administrator == null)
        {
            return new ActionResponse(false, "Student was not found.");
        }

        if ((await UserManager.DeleteAsync(administrator)) is var deleteResult && !deleteResult.Succeeded)
        {
            return new ActionResponse(false, deleteResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Student was deleted successfully.");
    }
}
