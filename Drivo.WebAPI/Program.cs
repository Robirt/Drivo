using Drivo.Entities;
using Drivo.WebAPI;
using Drivo.WebAPI.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Drivo")).UseLazyLoadingProxies());

builder.Services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.ConfigureJwtBearer(builder.Configuration.GetSection("JwtBearerToken")));

builder.Services.AddAuthorization();

builder.Services.AddScoped<PasswordService>();

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

application.MapControllers();

application.Run();
