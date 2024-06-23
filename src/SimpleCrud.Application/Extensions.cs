using Microsoft.Extensions.DependencyInjection;
using SimpleCrud.Application.Abstractions.Commands;
using SimpleCrud.Application.Abstractions.Dispatchers;
using SimpleCrud.Application.Queries;

namespace SimpleCrud.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {

        services.AddScoped<GetPhonesNumbers>();
        services.AddScoped<IDispatcher, Dispatchers>();
        // var applicationAssembly = typeof(ICommandHandler<>).Assembly;
        //
        // services.Scan(s => s.FromAssemblies(applicationAssembly)
        //     .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
        //     .AsImplementedInterfaces()
        //     .WithScopedLifetime());

        return services;
    }
}