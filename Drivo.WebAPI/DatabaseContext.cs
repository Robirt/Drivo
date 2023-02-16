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

	public virtual DbSet<AdministratorEntity> Administrators { get; set; }
	public virtual DbSet<LecturerEntity> Lecturers { get; set; }
	public virtual DbSet<InstructorEntity> Instructors { get; set; }
	public virtual DbSet<StudentEntity> Students { get; set; }
    public virtual DbSet<StudentsGroupEntity> StudentsGroups { get; set; }
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

		optionsBuilder.UseSqlServer(Configuration.GetConnectionString("Drivo")).UseLazyLoadingProxies();
    }

	protected override void OnModelCreating(ModelBuilder builder)
	{
		base.OnModelCreating(builder);

		builder.Entity<UserEntity>().Ignore(user => user.FullName);

        builder.Entity<LectureEntity>().Ignore(lecture => lecture.NumberOfHours);

        builder.Entity<DrivingEntity>().Ignore(driving => driving.NumberOfHours);

		builder.Entity<InternalExamEntity>().Ignore(internalExam => internalExam.NumberOfHours);

		builder.Entity<ExternalExamEntity>().Ignore(externalExam => externalExam.NumberOfHours);
    }
}
