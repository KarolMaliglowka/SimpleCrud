using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Infrastructure.DAL;

internal static class DependencyInjection
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString =
            "Host=127.0.0.1:5432;Database=SimpleCrudDb;Username=postgres;Password=postgres";
        
        services.AddDbContext<SimpleCrudDbContext>(x => x.UseNpgsql(connectionString));

        return services;
    }
}