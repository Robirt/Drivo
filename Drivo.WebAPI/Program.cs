using Drivo.Entities;
using Drivo.WebAPI;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<DatabaseContext>(options => options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Drivo;Integrated Security=True;").UseLazyLoadingProxies());

builder.Services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication(options => options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options => options.ConfigureJwtBearer(builder.Configuration.GetSection("JwtBearerToken")));

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options => options.ConfigureJsonOptions());

var application = builder.Build();

application.UseHttpsRedirection();

application.UseCors();

application.UseAuthentication();

application.UseAuthorization();

await application.UseDefaultRoles();

application.MapControllers();

application.Run();
