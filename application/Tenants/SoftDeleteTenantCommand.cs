using System;
using MediatR;

namespace application.Tenants
{
    public record SoftDeleteTenantCommand(Guid Id) : IRequest<Unit>;
}