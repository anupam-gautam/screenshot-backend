using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class TenantConfiguration : IEntityTypeConfiguration<Tenant>
    {
        public void Configure(EntityTypeBuilder<Tenant> builder)
        {
            builder.HasKey(t => t.Id);
            builder.Property(t => t.Name).IsRequired().HasMaxLength(255);
            builder.Property(t => t.Slug).IsRequired().HasMaxLength(100);
            builder.Property(t => t.Domain).HasMaxLength(255);
            builder.Property(t => t.PlanType).HasMaxLength(50);
            builder.Property(t => t.CreatedAt).IsRequired();

            builder.HasMany(t => t.PublisherUsers)
                .WithOne(p => p.Tenant)
                .HasForeignKey(p => p.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.EndUsers)
                .WithOne(e => e.Tenant)
                .HasForeignKey(e => e.TenantId)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(t => t.Books)
                .WithOne(b => b.Tenant)
                .HasForeignKey(b => b.TenantId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}