namespace Drivo.Entities
{
    public class DrivingEntity : EventEntity
    {
        public virtual StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
        public virtual InstructorEntity? Instructor { get; set; }
        public int? InstructorId { get; set; }
    }
}