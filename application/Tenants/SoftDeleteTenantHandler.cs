using System.Threading;
using System.Threading.Tasks;
using MediatR;
using application.Interfaces;

namespace application.Tenants
{
    public class SoftDeleteTenantHandler : IRequestHandler<SoftDeleteTenantCommand, Unit>
    {
        private readonly ITenantRepository _repo;
        public SoftDeleteTenantHandler(ITenantRepository repo) => _repo = repo;

        public async Task<Unit> Handle(SoftDeleteTenantCommand request, CancellationToken cancellationToken)
        {
            await _repo.SoftDeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}