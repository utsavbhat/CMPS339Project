namespace webapi.Models
{
    public class AttractionDetails
    {
        public int Id { get; set; }
        public int AttractionId { get; set; }
        public string? Name { get; set; }
        public int Capacity { get; set; }
        public TimeSpan? OpenTime { get; set; }
        public TimeSpan? CloseTime { get; set; }
        public int MinimumAge { get; set; }
        public int MinimumHeight { get; set; }
        public decimal TicketPrice { get; set; }
    }
}
