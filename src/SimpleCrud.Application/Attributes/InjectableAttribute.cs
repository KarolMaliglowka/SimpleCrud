using Microsoft.Extensions.DependencyInjection;

namespace SimpleCrud.Application.Attributes;

public class InjectableAttribute(ServiceLifetime lifeTime = ServiceLifetime.Transient) : Attribute
{
    public ServiceLifetime Lifetime { get; } = lifeTime;
}