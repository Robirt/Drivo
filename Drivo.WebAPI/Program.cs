var builder = WebApplication.CreateBuilder();

builder.Services.AddAuthentication();

builder.Services.AddAuthorization();

builder.Services.AddControllers();

var application = builder.Build();

application.UseHttpsRedirection();

application.UseAuthentication();

application.UseAuthorization();

application.MapControllers();

application.Run();
