using System;
using System.Collections.Generic;

namespace domain.Entities
{
    public class EndUser
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        public string Email { get; set; } = string.Empty;
        public string PasswordHash { get; set; } = string.Empty;
        public string FullName { get; set; } = string.Empty;
        public int LoginCount { get; set; }
        public DateTime? LastLoginAt { get; set; }
        public DateTime CreatedAt { get; set; }

        // Navigation
        public ICollection<UserSession> Sessions { get; set; } = new List<UserSession>();
        public ICollection<EndUserBook> EndUserBooks { get; set; } = new List<EndUserBook>();
        public ICollection<BookEncryptionKey> BookEncryptionKeys { get; set; } = new List<BookEncryptionKey>();
    }
}