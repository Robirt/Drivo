namespace Drivo.Entities
{
    public class LectureEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }    
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double NumberOfHours { get => (EndDate - StartDate).TotalHours; }
        public string Place { get; set; }   
        public virtual StudentsGroupEntity? StudentsGroup { get; set; }
        public int? StudentsGroupId { get; set; }
        public virtual LecturerEntity? Lecturer { get; set; }
        public int? LecturerId { get; set; }
    }
}
