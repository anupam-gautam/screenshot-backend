namespace application.Interfaces
{
    using System.Threading.Tasks;
    using domain.Entities;

    public interface ITodoRepository
    {
        Task<Todo?> GetByIdAsync(int id);
        Task UpdateAsync(Todo todo);
        Task AddAsync(Todo todo);
    }
}