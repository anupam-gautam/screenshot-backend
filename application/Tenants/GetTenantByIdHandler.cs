using System.Threading;
using System.Threading.Tasks;
using MediatR;
using application.Interfaces;

namespace application.Tenants
{
    public class GetTenantByIdHandler : IRequestHandler<GetTenantByIdQuery, domain.Entities.Tenant?>
    {
        private readonly ITenantRepository _repo;
        public GetTenantByIdHandler(ITenantRepository repo) => _repo = repo;

        public async Task<domain.Entities.Tenant?> Handle(GetTenantByIdQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetByIdAsync(request.Id);
        }
    }
}