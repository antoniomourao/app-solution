using AppShared.Domain;

namespace AppServer.Client;

public static class DomainExtensions
{
    public static IServiceCollection AddDomainClientServices(this IServiceCollection services)
    {
        services.AddSingleton<IDomainModule, DomainModule>();
        return services;
    }
}