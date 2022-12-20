namespace Drivo.Entities
{
    public class DrivingEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double NumberOfHours { get => (EndDate - StartDate).TotalHours; }
        public string StartPlace { get; set; }
        public StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
        public InstructorEntity? Instructor { get; set; }
        public int? InstructorId { get; set; }
    }
}
