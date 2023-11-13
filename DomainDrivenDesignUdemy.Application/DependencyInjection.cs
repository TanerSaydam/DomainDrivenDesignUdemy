using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Users;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesignUdemy.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssemblies(
                Assembly.GetExecutingAssembly(),
                typeof(Entity).Assembly);
        });

        return services;
    }
}
