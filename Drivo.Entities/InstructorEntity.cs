namespace Drivo.Entities
{
    public class InstructorEntity : UserEntity
    {
        public List<StudentEntity> Students { get; set; }   
    }
}
