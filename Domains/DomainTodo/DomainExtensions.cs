using AppShared.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace DomainTodo;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainTodoServices(this IServiceCollection services)
    {
        services.AddSingleton<IDomainModule, DomainModule>();
        return services;
    }
}