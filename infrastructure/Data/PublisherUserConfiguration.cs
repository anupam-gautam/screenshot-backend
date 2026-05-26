using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class PublisherUserConfiguration : IEntityTypeConfiguration<PublisherUser>
    {
        public void Configure(EntityTypeBuilder<PublisherUser> builder)
        {
            builder.HasKey(p => p.Id);
            builder.Property(p => p.Email).IsRequired().HasMaxLength(255);
            builder.Property(p => p.PasswordHash).IsRequired();
            builder.Property(p => p.FullName).HasMaxLength(255);
            builder.Property(p => p.Role).HasMaxLength(100);
            builder.Property(p => p.IsActive).IsRequired();
            builder.Property(p => p.CreatedAt).IsRequired();

            builder.HasMany(p => p.UploadedBooks)
                .WithOne(b => b.Uploader)
                .HasForeignKey(b => b.UploadedBy)
                .OnDelete(DeleteBehavior.SetNull);

            builder.HasMany(p => p.LockedBooks)
                .WithOne(b => b.Locker)
                .HasForeignKey(b => b.LockedBy)
                .OnDelete(DeleteBehavior.SetNull);
        }
    }
}