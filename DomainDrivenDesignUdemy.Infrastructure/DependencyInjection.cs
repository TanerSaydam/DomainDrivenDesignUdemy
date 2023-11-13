using DomainDrivenDesignUdemy.Domain.Abstractions;
using DomainDrivenDesignUdemy.Domain.Categories;
using DomainDrivenDesignUdemy.Domain.Orders;
using DomainDrivenDesignUdemy.Domain.Products;
using DomainDrivenDesignUdemy.Domain.Users;
using DomainDrivenDesignUdemy.Infrastructure.Context;
using DomainDrivenDesignUdemy.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DomainDrivenDesignUdemy.Infrastructure;
public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services)
    {

        services.AddScoped<ApplicationDbContext>();
        services.AddScoped<IUnitOfWork>(opt=> opt.GetRequiredService<ApplicationDbContext>());

        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<ICategoryRepository, CategoryRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        return services;
    }
}
