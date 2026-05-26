using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(b => b.Id);
            builder.Property(b => b.Title).IsRequired().HasMaxLength(1000);
            builder.Property(b => b.Author).HasMaxLength(500);
            builder.Property(b => b.ISBN).HasMaxLength(50);
            builder.Property(b => b.Format).HasMaxLength(100);
            builder.Property(b => b.FileUrl).HasMaxLength(2000);
            builder.Property(b => b.CoverUrl).HasMaxLength(2000);
            builder.Property(b => b.Status).HasMaxLength(100);
            builder.Property(b => b.CreatedAt).IsRequired();

            builder.HasMany(b => b.EncryptionKeys)
                .WithOne(k => k.Book)
                .HasForeignKey(k => k.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(b => b.EndUserBooks)
                .WithOne(eb => eb.Book)
                .HasForeignKey(eb => eb.BookId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}