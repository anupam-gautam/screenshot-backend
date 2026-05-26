using System.Threading;
using System.Threading.Tasks;
using MediatR;
using application.Interfaces;

namespace application.Tenants
{
    public class UpdateTenantHandler : IRequestHandler<UpdateTenantCommand, domain.Entities.Tenant?>
    {
        private readonly ITenantRepository _repo;
        public UpdateTenantHandler(ITenantRepository repo) => _repo = repo;

        public async Task<domain.Entities.Tenant?> Handle(UpdateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = await _repo.GetByIdAsync(request.Id);
            if (tenant == null) return null;
            if (!string.IsNullOrEmpty(request.Name)) tenant.Name = request.Name;
            if (!string.IsNullOrEmpty(request.PlanType)) tenant.PlanType = request.PlanType;
            if (request.IsActive.HasValue) tenant.IsActive = request.IsActive.Value;

            await _repo.UpdateAsync(tenant);
            return tenant;
        }
    }
}