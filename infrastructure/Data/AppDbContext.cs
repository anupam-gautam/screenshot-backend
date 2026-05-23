using Microsoft.EntityFrameworkCore;
using domain.Entities;

namespace infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; } = null!;
        public DbSet<Tenant> Tenants { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Tenant entity
            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(255);
                entity.Property(e => e.Slug).IsRequired().HasMaxLength(100);
                entity.Property(e => e.Domain).IsRequired().HasMaxLength(255);
                entity.Property(e => e.PlanType).IsRequired().HasMaxLength(50);

                // One Tenant to Many Todos
                entity.HasMany(e => e.Todos)
                    .WithOne(t => t.Tenant)
                    .HasForeignKey(t => t.TenantId)
                    .OnDelete(DeleteBehavior.Cascade);
            });

            // Configure Todo entity
            modelBuilder.Entity<Todo>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.Title).IsRequired().HasMaxLength(500);
                entity.Property(e => e.TenantId).IsRequired();

                // Foreign key constraint
                entity.HasOne(e => e.Tenant)
                    .WithMany(t => t.Todos)
                    .HasForeignKey(e => e.TenantId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}