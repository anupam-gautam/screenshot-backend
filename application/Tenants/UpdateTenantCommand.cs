using System;
using MediatR;

namespace application.Tenants
{
    public record UpdateTenantCommand(Guid Id, string? Name, string? PlanType, bool? IsActive) : IRequest<domain.Entities.Tenant?>;
}