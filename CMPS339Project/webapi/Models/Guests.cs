namespace webapi.Models
{
    public class Guests
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? MiddleInitial { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
