namespace Drivo.Entities
{
    public class PaymentEntity
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public DateTime EndTime { get; set; }
        public double Quantity { get; set; }
        public double Sum { get; set; } 
    }
}
