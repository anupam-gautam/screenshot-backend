using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class EndUserConfiguration : IEntityTypeConfiguration<EndUser>
    {
        public void Configure(EntityTypeBuilder<EndUser> builder)
        {
            builder.HasKey(e => e.Id);
            builder.Property(e => e.Email).IsRequired().HasMaxLength(255);
            builder.Property(e => e.PasswordHash).IsRequired();
            builder.Property(e => e.FullName).HasMaxLength(255);
            builder.Property(e => e.LoginCount).IsRequired();
            builder.Property(e => e.CreatedAt).IsRequired();

            builder.HasMany(e => e.EndUserBooks)
                .WithOne(eb => eb.EndUser)
                .HasForeignKey(eb => eb.EndUserId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(e => e.BookEncryptionKeys)
                .WithOne(k => k.EndUser)
                .HasForeignKey(k => k.EndUserId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}