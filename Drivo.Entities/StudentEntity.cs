namespace Drivo.Entities
{
    public class StudentEntity : UserEntity
    {
        public virtual List<PaymentEntity> Payments { get; set; }
    }
}