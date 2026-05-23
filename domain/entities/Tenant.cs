namespace domain.Entities
{
    public class Tenant
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Slug { get; set; }
        public string Domain { get; set; }
        public string PlanType { get; set; }
        public bool IsActive { get; set; }
        public DateTime Created_at { get; set; }

    }
}