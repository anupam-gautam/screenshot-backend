using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using application.Interfaces;
using domain.Entities;
using infrastructure.Data;

namespace infrastructure.Repositories
{
    public class TenantRepository : ITenantRepository
    {
        private readonly AppDbContext _db;

        public TenantRepository(AppDbContext db) => _db = db;

        //public async Task<Tenant?> GetByIdAsync(int id) => await _db.Todos.FindAsync(id);

        //public async Task UpdateAsync(Tenant tenant)
        //{
        //    _db.Todos.Update(tenant);
        //    await _db.SaveChangesAsync();
        //}

        public async Task<int> AddAsync(Tenant tenant)
        {
            _db.Tenants.Add(tenant);
            await _db.SaveChangesAsync();
            return tenant.Id;
        }
    }
}