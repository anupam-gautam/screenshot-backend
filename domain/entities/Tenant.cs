using domain.entities;

namespace domain.Entities
{
    public class Tenant : BaseEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; } = string.Empty;
        public string Domain { get; set; } = string.Empty;
        public string PlanType { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public ICollection<PublisherUser> PublisherUsers { get; set; } = new List<PublisherUser>();
        public ICollection<EndUser> EndUsers { get; set; } = new List<EndUser>();
        public ICollection<Book> Books { get; set; } = new List<Book>();
    }
}