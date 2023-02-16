namespace Drivo.Entities
{
    public class ExternalExamEntity : EventEntity
    {
        public virtual StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
    }
}
