using Drivo.Entities;
using Drivo.WebAPI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder();

builder.Services.AddCors(options => options.AddDefaultPolicy(policy => policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader()));

builder.Services.AddDbContext<DrivoContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("Drivo")).UseLazyLoadingProxies());

builder.Services.AddIdentity<UserEntity, RoleEntity>().AddEntityFrameworkStores<DrivoContext>().AddDefaultTokenProviders();

builder.Services.AddAuthentication().AddJwtBearer(options => options.ConfigureJwtBearer(builder.Configuration.GetSection("JwtBearerToken")));

builder.Services.AddAuthorization();

builder.Services.AddControllers().AddJsonOptions(options => options.ConfigureJsonOptions());

var application = builder.Build();

application.UseHttpsRedirection();

application.UseCors();

application.UseAuthentication();

application.UseAuthorization();

application.MapControllers();

application.Run();
