using System;

namespace domain.Entities
{
    public class UserSession
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string UserType { get; set; } = string.Empty; // 'PublisherUser' or 'EndUser'
        public string DeviceId { get; set; } = string.Empty;
        public string DevicePlatform { get; set; } = string.Empty;
        public string SessionTokenHash { get; set; } = string.Empty;
        public DateTime ExpiresAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}