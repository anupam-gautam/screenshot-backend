using System;
using MediatR;

namespace application.Tenants
{
    public record GetTenantByIdQuery(Guid Id) : IRequest<domain.Entities.Tenant?>;
}