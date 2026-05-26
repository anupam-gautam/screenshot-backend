using System;
using System.Collections.Generic;

namespace domain.Entities
{
    public class Book
    {
        public Guid Id { get; set; }
        public Guid TenantId { get; set; }
        public Tenant? Tenant { get; set; }

        public Guid UploadedBy { get; set; }
        public PublisherUser? Uploader { get; set; }

        public string Title { get; set; } = string.Empty;
        public string Author { get; set; } = string.Empty;
        public string ISBN { get; set; } = string.Empty;
        public string Format { get; set; } = string.Empty;
        public string FileUrl { get; set; } = string.Empty;
        public string CoverUrl { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public Guid? LockedBy { get; set; }
        public PublisherUser? Locker { get; set; }
        public DateTime? PublishedAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public ICollection<BookEncryptionKey> EncryptionKeys { get; set; } = new List<BookEncryptionKey>();
        public ICollection<EndUserBook> EndUserBooks { get; set; } = new List<EndUserBook>();
    }
}