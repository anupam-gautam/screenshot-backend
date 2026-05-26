using System;

namespace domain.Entities
{
    public class EndUserBook
    {
        public Guid Id { get; set; }
        public Guid EndUserId { get; set; }
        public EndUser? EndUser { get; set; }
        public Guid BookId { get; set; }
        public Book? Book { get; set; }

        public string AccessType { get; set; } = string.Empty;
        public bool IsDownloaded { get; set; }
        public DateTime? DownloadedAt { get; set; }
        public DateTime? LastReadAt { get; set; }
        public int ReadProgressPct { get; set; }
        public DateTime? ExpiresAt { get; set; }
        public DateTime? GrantedAt { get; set; }
    }
}