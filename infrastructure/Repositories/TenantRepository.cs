using System;
using System.Collections.Generic;
using System.Linq;
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

        public async Task<Guid> AddAsync(Tenant tenant)
        {
            _db.Tenants.Add(tenant);
            await _db.SaveChangesAsync();
            return tenant.Id;
        }

        public async Task<(IEnumerable<Tenant> Items, int Total)> GetPagedAsync(int page, int pageSize, string? planType, bool? isActive)
        {
            var query = _db.Tenants.AsQueryable();
            if (!string.IsNullOrEmpty(planType)) query = query.Where(t => t.PlanType == planType);
            if (isActive.HasValue) query = query.Where(t => t.IsActive == isActive.Value);

            var total = await query.CountAsync();
            var items = await query.OrderBy(t => t.Name).Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();
            return (items, total);
        }

        public async Task<Tenant?> GetByIdAsync(Guid id) => await _db.Tenants.FindAsync(id);

        public async Task UpdateAsync(Tenant tenant)
        {
            _db.Tenants.Update(tenant);
            await _db.SaveChangesAsync();
        }

        public async Task SoftDeleteAsync(Guid id)
        {
            var tenant = await _db.Tenants.FindAsync(id);
            if (tenant == null) return;
            tenant.IsActive = false;
            _db.Tenants.Update(tenant);
            await _db.SaveChangesAsync();
        }
    }
}