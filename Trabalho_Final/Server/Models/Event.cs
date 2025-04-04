// Models/Event.cs
namespace ES2.Data
{
    public class Event
    {
        public int Id { get; set; }
        public int OrganizerId { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        
        public DateTime EventStartDate { get; set; }
    
        public DateTime EventEndDate { get; set; }
        public string Location { get; set; }
        public int Capacity { get; set; }
        public string? Category { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public User? Organizer { get; set; }
        
    }
}