namespace Drivo.Entities
{
    public  class AdminEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public string Login { get; set; }   
        public List<StudentEntity> Students { get; set; }
        public List<InstructorEntity> Instructors { get; set; }
    }
}
