﻿namespace Drivo.Entities
{
    public class LecturerEntity
    {
        public int Id { get; set; }
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set; }
        public List<StudentsGroupEntity> StudentsGroups { get; set; }
    }

}