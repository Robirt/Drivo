namespace Drivo.Entities
{
    public class ExternalExamEntity
    {
        public int Id { get; set; } 
        public DateTime Date { get; set; }
        public string Place { get; set; }
        public virtual StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
    }
}
