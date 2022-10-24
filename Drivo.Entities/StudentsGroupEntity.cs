namespace Drivo.Entities
{
    public class StudentsGroupEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public List<StudentEntity> Students { get; set; }
        public List<LectureEntity> Lecture { get; set; }
        public List<DrivingEntity> Driving { get; set; }
    }
}
