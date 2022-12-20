﻿using Drivo.Entities;
using Drivo.Requests;
using Drivo.Responses;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI.Services;

public class AdministratorsService
{
    public AdministratorsService(UserManager<UserEntity> userManager)
    {
        UserManager = userManager;
    }

    private UserManager<UserEntity> UserManager { get; }

    public async Task<List<AdministratorEntity>> GetAdministratorsAsync()
    {
        return await UserManager.Users.OfType<AdministratorEntity>().ToListAsync();
    }

    public async Task<AdministratorEntity> GetAdministratorByUserNameAsync(string userName)
    {
        return await UserManager.Users.OfType<AdministratorEntity>().SingleOrDefaultAsync(user => user.UserName == userName);
    }

    public async Task<ActionResponse> CreateAdministratorAsync(CreateUserRequest request)
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

        var administrator = await GetAdministratorByUserNameAsync(userName);

        if ((await UserManager.AddToRoleAsync(administrator, "Administrator")) is var addToRoleResult && addToRoleResult.Succeeded == false)
        {
            return new ActionResponse(false, addToRoleResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Administrator was created successfully.");
    }

    public async Task<ActionResponse> DeleteAdministratorAsync(string userName)
    {
        var administrator = await GetAdministratorByUserNameAsync(userName);

        if (administrator == null)
        {
            return new ActionResponse(false, "Administrator was not found.");
        }

        if ((await UserManager.DeleteAsync(administrator)) is var deleteResult && !deleteResult.Succeeded)
        {
            return new ActionResponse(false, deleteResult.Errors.First().Description);
        }

        return new ActionResponse(true, "Administrator was deleted successfully.");
    }
}
