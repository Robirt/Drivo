using Drivo.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Drivo.WebAPI;

public class DatabaseContext : IdentityDbContext<UserEntity, RoleEntity, int>
{
	public DatabaseContext() : base()
	{

	}

	public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
	{

	}

	public DatabaseContext(DbContextOptions<DatabaseContext> options, IConfiguration configuration) : base(options)
	{
		Configuration = configuration;
	}

	private IConfiguration Configuration { get; }

    public virtual DbSet<StudentsGroupEntity> StudentsGroup { get; set; }
    public virtual DbSet<LectureEntity> Lectures { get; set; }
    public virtual DbSet<DrivingEntity> Drivings { get; set; }
    public virtual DbSet<AdEntity> Ads { get; set; }
    public virtual DbSet<CourseModuleEntity> CourseModules { get; set; }
    public virtual DbSet<ResourceEntity> Resources { get; set; }
    public virtual DbSet<ExternalExamEntity> ExternalExams { get; set; }
    public virtual DbSet<InternalExamEntity> InternalExams { get; set; }
    public virtual DbSet<PaymentEntity> Payments { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		base.OnConfiguring(optionsBuilder);

		optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Initial Catalog=Drivo;Integrated Security=True;").UseLazyLoadingProxies();

    }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<UserEntity>().Ignore(user => user.FullName);
	}
}
