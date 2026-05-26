using System;

namespace domain.Entities
{
    public class BookEncryptionKey
    {
        public Guid Id { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }
        public Guid EndUserId { get; set; }
        public EndUser? EndUser { get; set; }
        public string EncryptedKey { get; set; } = string.Empty;
        public DateTime? ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}