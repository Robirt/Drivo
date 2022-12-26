namespace Drivo.Entities
{
    public class LectureEntity : EventEntity
    {
        public virtual StudentsGroupEntity? StudentsGroup { get; set; }
        public int? StudentsGroupId { get; set; }
        public virtual LecturerEntity? Lecturer { get; set; }
        public int? LecturerId { get; set; }
    }
}