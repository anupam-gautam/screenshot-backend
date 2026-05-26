namespace application.Interfaces
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using domain.Entities;

    public interface ITenantRepository
    {
        Task<Guid> AddAsync(Tenant tenant);
        Task<(IEnumerable<Tenant> Items, int Total)> GetPagedAsync(int page, int pageSize, string? planType, bool? isActive);
        Task<Tenant?> GetByIdAsync(Guid id);
        Task UpdateAsync(Tenant tenant);
        Task SoftDeleteAsync(Guid id);
    }
}