using AppShared.Domain;
using Microsoft.Extensions.DependencyInjection;

namespace AppWeather;

public static class DomainExtensions
{
    public static IServiceCollection AddAppWeatherServices(this IServiceCollection services)
    {

        // setup weather forecast service
                    services.AddScoped(provider =>
            {
                var config = provider.GetRequiredService<IOptions<WeatherConfiguration>>();
                return new WeatherAPIClient(config.Value.ApiKey, config.Value.Url);
            });

            // services.AddHttpClient("weather", (provider, client) =>
            // {
            //     var config = provider.GetRequiredService<WeatherConfiguration>();
            //     client.BaseAddress = config.Url;
            // })
            // .AddHttpMessageHandler<WeatherApiKeyHandler>();
        return services;
    }
}