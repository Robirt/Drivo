namespace Drivo.Entities
{
    public class LecturerEntity : UserEntity
    {
        public LecturerEntity() : base()
        {

        }

        public LecturerEntity(string userName, string email, string firstName, string lastName, DateTime birthDate) : base(userName, email, firstName, lastName, birthDate)
        {

        }

        public virtual List<StudentsGroupEntity> StudentsGroups { get; set; }
        public virtual List<LectureEntity> Lectures { get; set; }
    }
}
