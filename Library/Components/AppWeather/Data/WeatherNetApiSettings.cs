namespace AppWeather;

using System.ComponentModel.DataAnnotations;
using Microsoft.Extensions.Options;

public class WeatherNetApiSettings
{
    [Required]
    public string WeatherApiKey { get; set; } = null!;

    [Required]
    public string WeatherApiUrl { get; set; } = null!;

    [Required]
    public string Query { get; set; } = null!;

    [Required]
    public int Days { get; set; } = 1;

    [Required]
    public string Aqi { get; set; } = null!;

    [Required]
    public string Alerts { get; set; } = null!;
}

public static class WeatherNetApiSettingsExtensions
{
    public static string BuildFullUrl(this IOptionsMonitor<WeatherNetApiSettings> settings)
    {
        return $"{settings.CurrentValue.WeatherApiUrl}key={settings.CurrentValue.WeatherApiKey}&q={settings.CurrentValue.Query}&days={settings.CurrentValue.Days}&aqi={settings.CurrentValue.Aqi}&alerts={settings.CurrentValue.Alerts}";
    }
}
