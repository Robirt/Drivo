namespace Drivo.Entities
{
    public class DrivingEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Date { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double NumberOfHours { get; set; }
        public double CurrentNumberOfHours { get; set; }
        public string Place { get; set; }
    }
}
