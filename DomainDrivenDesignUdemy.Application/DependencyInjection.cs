﻿using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace DomainDrivenDesignUdemy.Application;
public static class DependencyInjection
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services)
    {
        services.AddMediatR(cfr =>
        {
            cfr.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly());
        });

        return services;
    }
}
