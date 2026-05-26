using MediatR;

namespace application.Tenants
{
    public record ListTenantsQuery(int Page, int PageSize, string? PlanType, bool? IsActive) : IRequest<PagedResult<domain.Entities.Tenant>>;
}