namespace Drivo.Entities
{
    public class StudentEntity
    {
        public int Id { get; set; } 
        public string Firstname { get; set; }
        public string Surname { get; set; }
        public DateTime Birthdate { get; set;  }
        public List<PaymentEntity> Payment { get; set; }
    }
}