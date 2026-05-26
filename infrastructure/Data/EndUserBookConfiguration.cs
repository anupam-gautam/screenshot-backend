using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class EndUserBookConfiguration : IEntityTypeConfiguration<EndUserBook>
    {
        public void Configure(EntityTypeBuilder<EndUserBook> builder)
        {
            builder.HasKey(eb => eb.Id);
            builder.Property(eb => eb.AccessType).HasMaxLength(100);
            builder.Property(eb => eb.ReadProgressPct);
        }
    }
}