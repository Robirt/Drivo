namespace Drivo.Entities
{
    public class StudentEntity : UserEntity
    {
        public StudentEntity() : base()
        {

        }

        public StudentEntity(string userName, string email, string firstName, string lastName, DateTime birthDate) : base(userName, email, firstName, lastName, birthDate)
        {

        }

        public virtual StudentsGroupEntity? StudentsGroup { get; set; }
        public int? StudentsGroupId { get; set; }
        public virtual List<DrivingEntity> Drivings { get; set; }
        public virtual List<InternalExamEntity> InternalExams { get; set; }
        public virtual List<ExternalExamEntity> ExternalExams { get; set; }
        public virtual List<PaymentEntity> Payments { get; set; }
    }
}