using MediatR;

namespace application.Todos.Commands
{
    public record CreateTenantCommand(
        string Name,
        string Slug,
        string Domain,
        string PlanType,
        bool IsActive
    ) : IRequest<Guid>;
}