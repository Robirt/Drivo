namespace Drivo.Entities
{
    public class InternalExamEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string StartPlace { get; set; }
        public StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
        public InstructorEntity? Instructor { get; set; }
        public int? InstructorId { get; set; }
    }
}
