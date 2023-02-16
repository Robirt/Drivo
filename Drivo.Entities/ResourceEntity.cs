namespace Drivo.Entities
{
    public class ResourceEntity
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Content { get; set; }
        public byte[] Image { get; set; }
        public virtual CourseModuleEntity? CourseModule { get; set; }
        public int? CourseModuleId { get; set; }
    }
}
