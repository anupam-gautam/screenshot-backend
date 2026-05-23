using MediatR;
using System.Threading;
using System.Threading.Tasks;
using application.Interfaces;
using domain.Entities;
using application.Todos.Commands;

namespace application.Todos.Handlers
{
    public class CreateTenantHandler : IRequestHandler<CreateTenantCommand, int>
    {
        private readonly ITenantRepository _repository;

        public CreateTenantHandler(ITenantRepository repository) => _repository = repository;

        public async Task<int> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        {
            var tenant = new Tenant
            {
                Name = request.Name,
                Slug = request.Slug,
                Domain = request.Domain,
                PlanType = request.PlanType,
                IsActive = request.IsActive,
                Created_at = DateTime.UtcNow
            };

            await _repository.AddAsync(tenant);
            return tenant.Id;
        }
    }
}