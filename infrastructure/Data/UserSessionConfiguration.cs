using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class UserSessionConfiguration : IEntityTypeConfiguration<UserSession>
    {
        public void Configure(EntityTypeBuilder<UserSession> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.UserType).IsRequired().HasMaxLength(50);
            builder.Property(s => s.DeviceId).HasMaxLength(255);
            builder.Property(s => s.DevicePlatform).HasMaxLength(100);
            builder.Property(s => s.SessionTokenHash).IsRequired();
            builder.Property(s => s.ExpiresAt).IsRequired();
            builder.Property(s => s.CreatedAt).IsRequired();
        }
    }
}