namespace Drivo.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndDate { get; set; }
        public int Number { get; set; }
        public double Ammount { get; set; }
        public virtual StudentEntity? Student { get; set; }
        public int? StudentId { get; set; }
    }
}
