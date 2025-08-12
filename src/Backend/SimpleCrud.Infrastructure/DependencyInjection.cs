using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Core.Repositories;
using SimpleCrud.Infrastructure.DAL;
using SimpleCrud.Infrastructure.DAL.Repositories;

namespace SimpleCrud.Infrastructure;

public static class DependencyInjection
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services
            .AddPostgres(configuration)
            .AddScoped<IPhoneBookRepository, PhoneBookRepository>();

        return services;
    }
}