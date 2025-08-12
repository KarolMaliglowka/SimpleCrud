using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Infrastructure.DAL;

internal static class DependencyInjection
{
    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetSection("postgres:connectionString").Value;
        services.AddDbContext<SimpleCrudDbContext>(x => x.UseNpgsql(connectionString));

        return services;
    }
}