namespace Drivo.Entities
{
    public class StudentsGroupEntity
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public virtual List<StudentEntity> Students { get; set; }
        public virtual List<LectureEntity> Lectures { get; set; }
    }
}
