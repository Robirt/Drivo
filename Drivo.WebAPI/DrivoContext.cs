using Drivo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI;

public class DrivoContext : IdentityDbContext<UserEntity, RoleEntity, int>
{
	public DrivoContext() : base()
	{

	}

	public DrivoContext(DbContextOptions<DrivoContext> options) : base(options)
	{

	}

	public DrivoContext(DbContextOptions<DrivoContext> options, IConfiguration configuration) : base(options)
	{
		Configuration = configuration;
	}

	private IConfiguration Configuration { get; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Drivo")).UseLazyLoadingProxies();
	}

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<UserEntity>().Ignore(user => user.FullName);
	}
}
