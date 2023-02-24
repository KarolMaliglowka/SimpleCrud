using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Core.Repositories;
using SimpleCrud.Infrastructure.DAL.Repositories;

namespace SimpleCrud.Infrastructure.DAL;

internal static class Extensions
{
    private const string OptionsSectionName = "postgres";

    public static IServiceCollection AddPostgres(this IServiceCollection services, IConfiguration configuration)
    {
        services.Configure<PostgresOptions>(configuration.GetRequiredSection(OptionsSectionName));
        var postgresOptions = configuration.GetOptions<PostgresOptions>(OptionsSectionName);
        services.AddDbContext<SimpleCrudDbContext>(x => x.UseNpgsql(postgresOptions.ConnectionString));
        services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();

        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

        return services;
    }
}