using Microsoft.EntityFrameworkCore;
using domain.Entities;

namespace infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Todo> Todos { get; set; } = null!;
        public DbSet<Tenant> Tenants { get; set; } = null!;

    }
}