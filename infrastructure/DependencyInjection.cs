using Microsoft.Extensions.DependencyInjection;
using MediatR;
using FluentValidation;
using application;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Register infrastructure implementations here.
            // Example:
            // services.AddScoped<IUserRepository, SqlUserRepository>();

            // Register MediatR handlers (scans the application assembly for IRequest/IRequestHandler)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(application.Class1)));

            // Register FluentValidation validators from the application assembly
            services.AddValidatorsFromAssemblyContaining(typeof(application.Class1));

            // Register pipeline behavior to run validators for MediatR requests
            services.AddTransient(typeof(MediatR.IPipelineBehavior<,>), typeof(application.ValidationBehavior<,>));

            return services;
        }
    }
}
