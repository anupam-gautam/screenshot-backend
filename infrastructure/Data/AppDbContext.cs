using Microsoft.EntityFrameworkCore;
using domain.Entities;

namespace infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        //public DbSet<Todo> Todos { get; set; } = null!;
        public DbSet<Tenant> Tenants { get; set; } = null!;

        public DbSet<SuperAdmin> SuperAdmins { get; set; } = null!;
        public DbSet<PublisherUser> PublisherUsers { get; set; } = null!;
        public DbSet<EndUser> EndUsers { get; set; } = null!;
        public DbSet<UserSession> UserSessions { get; set; } = null!;
        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<BookEncryptionKey> BookEncryptionKeys { get; set; } = null!;
        public DbSet<EndUserBook> EndUserBooks { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Apply entity configurations from this assembly to keep DbContext clean
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}