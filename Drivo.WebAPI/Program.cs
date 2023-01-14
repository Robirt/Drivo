using Drivo.Entities;
using Drivo.WebAPI;
using Drivo.WebAPI.Services;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using MimeKit;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Drivo")).UseLazyLoadingProxies());

builder.Services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<DatabaseContext>();

builder.Services.AddScoped<JwtBearerTokensService>();
builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.ConfigureJwtBearer(builder.Configuration.GetSection("JwtBearerToken")));

builder.Services.AddAuthorization();

builder.Services.AddScoped<PasswordsService>();

builder.Services.AddMailsService(builder.Configuration.GetSection("Smpt"));

builder.Services.AddUsersServices();

builder.Services.AddEntitiesRepositories();

builder.Services.AddEntitiesServices();

builder.Services.AddHostedService<BackgroundNotificationsService>();

builder.Services.AddControllers().AddJsonOptions(options => options.ConfigureJsonOptions());

var application = builder.Build();

application.UseHttpsRedirection();

application.UseCors();

application.UseAuthentication();

application.UseAuthorization();

application.MigrateDatabase();

application.MapRoles();

application.MapControllers();

application.CreateSuperAdministrator(application.Configuration.GetSection("SuperAdministrator"));

application.Run();
