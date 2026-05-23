using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using MediatR;
using FluentValidation;
using application;
using Microsoft.EntityFrameworkCore;
using infrastructure.Data;
using application.Interfaces;
using infrastructure.Repositories;
using application.Todos.Commands;
using Npgsql.EntityFrameworkCore.PostgreSQL;

namespace infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Register infrastructure implementations here.
            // Example:
            // services.AddScoped<IUserRepository, SqlUserRepository>();

            // Register MediatR handlers (scans the application assembly for IRequest/IRequestHandler)
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining(typeof(CreateTenantCommand)));

            // Register FluentValidation validators from the application assembly
            services.AddValidatorsFromAssemblyContaining(typeof(CreateTenantCommand));

            // Register pipeline behavior to run validators for MediatR requests
            services.AddTransient(typeof(MediatR.IPipelineBehavior<,>), typeof(application.ValidationBehavior<,>));

            // Register EF Core with PostgreSQL
            // Scoped lifetime ensures each HTTP request gets its own DbContext instance
            // This is essential for multi-tenant data isolation
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")),
                ServiceLifetime.Scoped);

            // Register repository implementations
            services.AddScoped<ITenantRepository, TenantRepository>();

            return services;
        }
    }
}
