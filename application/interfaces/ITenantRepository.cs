namespace application.Interfaces
{
    using System.Threading.Tasks;
    using domain.Entities;

    public interface ITenantRepository
    {

        Task<int> AddAsync(Tenant tenant);
    }
}