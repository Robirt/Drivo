namespace Drivo.Entities
{
    public class LecturerEntity : UserEntity
    {
        public virtual List<StudentsGroupEntity> StudentsGroups { get; set; }
    }
}
