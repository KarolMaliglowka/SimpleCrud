using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        return services;
    }
}