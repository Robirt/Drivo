using Castle.Core.Internal;
using Drivo.Entities;
using Drivo.WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

public static class ProgramExtensions
{
    public static async Task<WebApplication> UseDefaultRoles(this WebApplication webApplication)
    {
        using (var roleManager = webApplication.Services.CreateAsyncScope().ServiceProvider.GetService<RoleManager<RoleEntity>>())
        {
            await roleManager.CreateAsync(new RoleEntity("Lecturer"));
            await roleManager.CreateAsync(new RoleEntity("Instructor"));
            await roleManager.CreateAsync(new RoleEntity("Student"));
        }

        return webApplication;
    }

    public static void ConfigureJwtBearer(this JwtBearerOptions options, IConfigurationSection configuration)
    {
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("IssuerSigningKey")));
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidIssuer = configuration.GetValue<string>("ValidIssuer");
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateLifetime = true;
    }

    public static void ConfigureJsonOptions(this JsonOptions options)
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    }
}
