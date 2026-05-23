using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using application.Interfaces;
using domain.Entities;
using infrastructure.Data;

namespace infrastructure.Repositories
{
    public class TodoRepository : ITodoRepository
    {
        private readonly AppDbContext _db;

        public TodoRepository(AppDbContext db) => _db = db;

        public async Task<Todo?> GetByIdAsync(int id) => await _db.Todos.FindAsync(id);

        public async Task UpdateAsync(Todo todo)
        {
            _db.Todos.Update(todo);
            await _db.SaveChangesAsync();
        }

        public async Task AddAsync(Todo todo)
        {
            _db.Todos.Add(todo);
            await _db.SaveChangesAsync();
        }
    }
}