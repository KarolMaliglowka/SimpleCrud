using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Core;

public static class Extensions
{
    public static IServiceCollection AddCore(this IServiceCollection services)
    {
        //services.AddSingleton<IPhoneBookRepository, phone>();
            
        return services;
    }

}