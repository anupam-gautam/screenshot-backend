using FluentValidation;
using application.Todos.Commands;

namespace application.Todos.Validators
{
    public class CreateTenantCommandValidator : AbstractValidator<CreateTenantCommand>
    {
        public CreateTenantCommandValidator()
        {
            //RuleFor(x => x.Title).NotEmpty().MaximumLength(200);
        }
    }
}