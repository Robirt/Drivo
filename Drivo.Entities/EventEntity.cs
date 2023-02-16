namespace Drivo.Entities
{
    public class EventEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public double NumberOfHours { get => (EndDate - StartDate).TotalHours; }
        public string Place { get; set; }
    }
}