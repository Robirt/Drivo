namespace Drivo.Entities
{
    public class InstructorEntity : UserEntity
    {
        public InstructorEntity() : base()
        {

        }

        public InstructorEntity(string userName, string email, string firstName, string lastName, DateTime birthDate, string phoneNumber) : base(userName, email, firstName, lastName, birthDate, phoneNumber)
        {

        }

        public virtual List<StudentEntity>? Students { get; set; }
        public virtual List<DrivingEntity>? Drivings { get; set; }
        public virtual List<InternalExamEntity>? InternalExams { get; set; }
    }
}
