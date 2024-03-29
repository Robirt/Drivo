﻿using Drivo.Entities;
using Drivo.MAUI.Services;
using Drivo.MAUI.ViewModels;
using Drivo.MAUI.Views;

namespace Drivo.MAUI;

public static class MauiProgramExtensions
{
    public static IServiceCollection AddViews(this IServiceCollection services)
    {
        services.AddSingleton<SignInPage>();
        
        services.AddSingleton<HomePage>();
        services.AddSingleton<CalendarPage>();
        services.AddSingleton<CourseModulesPage>();
        services.AddSingleton<CourseModulePage>();
        services.AddSingleton<ProfilePage>();
        services.AddSingleton<ExternalExamAddPage>();

        return services;
    }

    public static IServiceCollection AddViewModels(this IServiceCollection services)
    {
        services.AddSingleton<SignInPageViewModel>();

        services.AddSingleton<HomePageViewModel>();
        services.AddSingleton<CalendarPageViewModel>();
        services.AddSingleton<CourseModulesPageViewModel>();
        services.AddSingleton<CourseModulePageViewModel>();
        services.AddSingleton<ProfilePageViewModel>();
        services.AddSingleton<ExternalExamAddPageViewModel>();

        return services;
    }

    public static IServiceCollection AddServices(this IServiceCollection services)
    {
        services.AddScoped<UserService>();

        services.AddScoped<LecturersService>();
        services.AddScoped<InstructorsService>();

        services.AddScoped<CourseModulesService>();

        services.AddScoped<LectureEntity>();
        services.AddScoped<DrivingsService>();
        services.AddScoped<InternalExamsService>();
        services.AddScoped<ExternalExamsService>();

        services.AddScoped<AdsService>();

        services.AddScoped<PaymentsService>();

        return services;
    }
}
