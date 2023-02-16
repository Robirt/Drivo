namespace Drivo.Entities
{
    public class CourseModuleEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Image { get; set; }
        public virtual List<ResourceEntity>? Resources { get; set; }
    }
}
