using System;
using System.Collections.Generic;

namespace domain.Entities
{
    public class PublisherUser
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public bool IsActive { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<Book> UploadedBooks { get; set; } = new List<Book>();
        public ICollection<Book> LockedBooks { get; set; } = new List<Book>();
        public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
    }
}