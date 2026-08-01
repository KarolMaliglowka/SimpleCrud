using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Services;

namespace SimpleCrud.Application;

public static class DependencyInjection
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services
            .AddScoped<IPhoneService, PhoneService>();
        return services;
    }
}