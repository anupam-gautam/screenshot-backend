using System.Threading;
using System.Threading.Tasks;
using MediatR;
using application.Interfaces;

namespace application.Tenants
{
    public class ListTenantsHandler : IRequestHandler<ListTenantsQuery, PagedResult<domain.Entities.Tenant>>
    {
        private readonly ITenantRepository _repo;
        public ListTenantsHandler(ITenantRepository repo) => _repo = repo;

        public async Task<PagedResult<domain.Entities.Tenant>> Handle(ListTenantsQuery request, CancellationToken cancellationToken)
        {
            var (items, total) = await _repo.GetPagedAsync(request.Page <= 0 ? 1 : request.Page, request.PageSize <= 0 ? 20 : request.PageSize, request.PlanType, request.IsActive);
            return new PagedResult<domain.Entities.Tenant> { Items = items, Total = total };
        }
    }
}