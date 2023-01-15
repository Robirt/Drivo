using Drivo.Entities;
using Drivo.Requests;
using Drivo.WebAPI;
using Drivo.WebAPI.Repositories;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Text.Json.Serialization;

public static class ProgramExtensions
{
    public static void ConfigureJwtBearer(this JwtBearerOptions options, IConfigurationSection configuration)
    {
        options.TokenValidationParameters.ValidateIssuerSigningKey = true;
        options.TokenValidationParameters.IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("IssuerSigningKey")));
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidIssuer = configuration.GetValue<string>("ValidIssuer");
        options.TokenValidationParameters.ValidateAudience = false;
        options.TokenValidationParameters.ValidateLifetime = true;
    }

    public static IServiceCollection AddUsersServices(this IServiceCollection services)
    {
        services.AddScoped<UsersService>();

        services.AddScoped<AdministratorsService>();
        services.AddScoped<LecturersService>();
        services.AddScoped<InstructorsService>();
        services.AddScoped<StudentsService>();

        return services;
    }

    public static IServiceCollection AddEntitiesRepositories(this IServiceCollection services)
    {
        services.AddScoped<StudentsGroupsRepository>();
        services.AddScoped<LecturesRepository>();
        services.AddScoped<DrivingsRepository>();
        services.AddScoped<AdsRepository>();
        services.AddScoped<CourseModulesRepository>();
        services.AddScoped<ResourcesRepository>();
        services.AddScoped<ExternalExamsRepository>();
        services.AddScoped<InternalExamsRepository>();
        services.AddScoped<PaymentsRepository>();

        return services;
    }

    public static IServiceCollection AddEntitiesServices(this IServiceCollection services)
    {
        services.AddScoped<StudentsGroupsService>();
        services.AddScoped<LecturesSevice>();
        services.AddScoped<DrivingsService>();
        services.AddScoped<AdsService>();
        services.AddScoped<CourseModulesService>();
        services.AddScoped<ResourcesService>();
        services.AddScoped<ExternalExamsService>();
        services.AddScoped<InternalExamsService>();
        services.AddScoped<PaymentsService>();

        return services;
    }

    public static IServiceCollection AddMailsService(this IServiceCollection services, IConfigurationSection configuration)
    {
        services.AddScoped(serviceProvider => new SmtpClient(configuration.GetValue<string>("Host"), configuration.GetValue<int>("Port")) { Credentials = new NetworkCredential(configuration.GetValue<string>("Credentials:UserName"), configuration.GetValue<string>("Credentials:Password")), EnableSsl = true });
        services.AddScoped<MailsService>();

        return services;
    }

    public static void ConfigureJsonOptions(this JsonOptions options)
    {
        options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
        options.JsonSerializerOptions.WriteIndented = true;
    }

    public static IApplicationBuilder MigrateDatabase(this IApplicationBuilder app)
    {
        using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
        {
            serviceScope.ServiceProvider.GetRequiredService<DatabaseContext>().Database.Migrate();
        }

        return app;
    }

    public static IApplicationBuilder MapRoles(this IApplicationBuilder app)
    {
        using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
        {
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<RoleEntity>>();

            if (!roleManager.Roles.Any())
            {
                roleManager.CreateAsync(new RoleEntity("Administrator")).Wait();
                roleManager.CreateAsync(new RoleEntity("Lecturer")).Wait();
                roleManager.CreateAsync(new RoleEntity("Instructor")).Wait();
                roleManager.CreateAsync(new RoleEntity("Student")).Wait();
            }
        }

        return app;
    }

    public static IApplicationBuilder CreateSuperAdministrator(this IApplicationBuilder app, IConfigurationSection configuration)
    {
        using (IServiceScope serviceScope = app.ApplicationServices.CreateScope())
        {
            var administratorsService = serviceScope.ServiceProvider.GetRequiredService<AdministratorsService>();

            if (administratorsService.GetAdministratorsAsync().Result is var administrators && administrators is null || !administrators.Any())
            {
                administratorsService.CreateAdministratorAsync(configuration.Get<CreateUserRequest>()).Wait();
            }
        }

        return app;
    }
}
