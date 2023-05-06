using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Infrastructure.DAL;

internal static class Extension
{
    public static IServiceCollection AddPostgres(this IServiceCollection services)
    {
        const string connectionString =
            "Host=192.168.77.202;Database=SimpleCrudDb;Username=postgresuser;Password=kalifornia";
        services.AddDbContext<SimpleCrudDbContext>(x => x.UseNpgsql(connectionString));

        return services;
    }
}