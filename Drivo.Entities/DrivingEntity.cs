namespace Drivo.Entities
{
    public class DrivingEntity : EventEntity
    {
        public StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
        public InstructorEntity? Instructor { get; set; }
        public int? InstructorId { get; set; }
    }
}