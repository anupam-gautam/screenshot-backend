namespace domain.Entities
{
    public class Todo
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool IsDone { get; set; }
        public int TenantId { get; set; }

        // Navigation property
        public Tenant? Tenant { get; set; }
    }
}