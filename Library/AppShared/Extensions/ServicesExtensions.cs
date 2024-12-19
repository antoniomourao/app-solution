using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace AppShared.Extensions;
public static class ServicesExtensions
{
    /// <summary>
    /// Register Settings from appsettings.json for specific class
    /// to be used by any class that needs it.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    public static T RegisterAppSettings<T>(
        this IServiceCollection services, 
        IConfiguration configuration) where T : class, new()
    {
        // precisa de ser feito antes da chamada ao RegisterAppSettings
        // services.AddOptions<T>()
        //     .Bind(configuration)
        //     .ValidateDataAnnotations();

        var instance = services
            .BuildServiceProvider()
            .GetRequiredService<IOptionsMonitor<T>>()
            .CurrentValue;
        services.AddSingleton(_ => instance);

        return instance;
    }
}
