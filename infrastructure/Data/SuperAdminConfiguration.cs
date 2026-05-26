using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using domain.Entities;

namespace infrastructure.Data
{
    public class SuperAdminConfiguration : IEntityTypeConfiguration<SuperAdmin>
    {
        public void Configure(EntityTypeBuilder<SuperAdmin> builder)
        {
            builder.HasKey(s => s.Id);
            builder.Property(s => s.Email).IsRequired().HasMaxLength(255);
            builder.Property(s => s.PasswordHash).IsRequired();
            builder.Property(s => s.FullName).HasMaxLength(255);
            builder.Property(s => s.CreatedAt).IsRequired();
        }
    }
}