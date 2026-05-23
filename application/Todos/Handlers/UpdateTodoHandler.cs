using MediatR;
using System.Threading;
using System.Threading.Tasks;
using application.Interfaces;
using domain.Entities;
using application.Todos.Commands;

namespace application.Todos.Handlers
{
    //public class d : IRequestHandler<CreateTenantCommand, bool>
    //{
    //    private readonly ITodoRepository _repository;

    //    public CreateTenantHandler(ITodoRepository repository) => _repository = repository;

        //public async Task<bool> Handle(CreateTenantCommand request, CancellationToken cancellationToken)
        //{
        //    var todo = await _repository.GetByIdAsync(request.Id);
        //    if (todo == null) return false;

        //    todo.Title = request.Title;
        //    todo.IsDone = request.IsDone;

        //    await _repository.UpdateAsync(todo);
        //    return true;
        //}
    //}
}