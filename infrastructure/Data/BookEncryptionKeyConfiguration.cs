using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class BookEncryptionKeyConfiguration : IEntityTypeConfiguration<BookEncryptionKey>
    {
        public void Configure(EntityTypeBuilder<BookEncryptionKey> builder)
        {
            builder.HasKey(k => k.Id);
            builder.Property(k => k.EncryptedKey).IsRequired();
            builder.Property(k => k.CreatedAt).IsRequired();
        }
    }
}