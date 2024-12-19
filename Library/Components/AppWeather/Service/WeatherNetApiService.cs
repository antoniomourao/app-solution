using System;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace AppWeather;

public interface IWeatherNetApiService
{
    Task<WeatherNetApiResult?> GetWeatherAsync(string? city);
}

public class WeatherNetApiService : IWeatherNetApiService
{
    private readonly IOptionsMonitor<WeatherNetApiSettings> _settings;
    private readonly HttpClient _httpClient;

    public WeatherNetApiService(
        IOptionsMonitor<WeatherNetApiSettings> settings,
        HttpClient httpClient
    )
    {
        _settings = settings;
        _httpClient = httpClient;
    }

    public async Task<WeatherNetApiResult?> GetWeatherAsync(string? city)
    {
        var url = _settings.BuildFullUrl();
        var response = await _httpClient.GetAsync(url);
        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            return !String.IsNullOrEmpty(content)? JsonConvert.DeserializeObject<WeatherNetApiResult>(content) : null;
        }

        return null;
    }
}

public class WeatherNetApiResult
{
    public WeatherNetApiResultLocation Location { get; set; } = null!;
    public WeatherNetApiResultCurrent Current { get; set; } = null!;
    public WeatherNetApiResultForecast Forecast { get; set; } = null!;
}

public class WeatherNetApiResultLocation
{
    public string? name { get; set; }
    public string? country { get; set; }
    public string? region { get; set; }
    public string? lat { get; set; }
    public string? lon { get; set; }
    public string? timezone_id { get; set; }
    public string? localtime { get; set; }
    public int? localtime_epoch { get; set; }
    public string? utc_offset { get; set; }
}

public class WeatherNetApiResultCurrent
{
    public string? last_updated { get; set; }
    public int? temp_c { get; set; }
    public int? temp_f { get; set; }
    public int? is_day { get; set; }
    public WeatherNetApiResultCondition? Condition { get; set; }
    public int? wind_mph { get; set; }
    public int? wind_kph { get; set; }
    public int? wind_degree { get; set; }
    public string? wind_dir { get; set; }
    public int? pressure_mb { get; set; }
    public int? pressure_in { get; set; }
    public int? precip_mm { get; set; }
    public int? precip_in { get; set; }
    public int? humidity { get; set; }
    public int? cloud { get; set; }
    public int? feelslike_c { get; set; }
    public int? feelslike_f { get; set; }
    public int? vis_km { get; set; }
    public int? vis_miles { get; set; }
    public int? uv { get; set; }
    public int? gust_mph { get; set; }
    public int? gust_kph { get; set; }
}

public class WeatherNetApiResultForecast
{
    public List<WeatherNetApiResultForecastDay>? ForecastDay { get; set; }
}

public class WeatherNetApiResultForecastDay
{
    public string? date { get; set; }
    public int? date_epoch { get; set; }
    public WeatherNetApiResultForecastDayDay? Day { get; set; }
    public WeatherNetApiResultForecastDayAstro? Astro { get; set; }
    public List<WeatherNetApiResultForecastDayHour>? Hour { get; set; }
}

public class WeatherNetApiResultForecastDayHour
{
    public string? time { get; set; }
    public int? time_epoch { get; set; }
    public int? temp_c { get; set; }
    public int? temp_f { get; set; }
    public int? is_day { get; set; }
    public WeatherNetApiResultCondition? Condition { get; set; }
    public int? wind_mph { get; set; }
    public int? wind_kph { get; set; }
    public int? wind_degree { get; set; }
    public string? wind_dir { get; set; }
    public int? pressure_mb { get; set; }
    public int? pressure_in { get; set; }
    public int? precip_mm { get; set; }
    public int? precip_in { get; set; }
    public int? humidity { get; set; }
    public int? cloud { get; set; }
    public int? feelslike_c { get; set; }
    public int? feelslike_f { get; set; }
    public int? windchill_c { get; set; }
    public int? windchill_f { get; set; }
    public int? heatindex_c { get; set; }
    public int? heatindex_f { get; set; }
    public int? dewpoint_c { get; set; }
    public int? dewpoint_f { get; set; }
    public int? will_it_rain { get; set; }
    public string? chance_of_rain { get; set; }
    public int? will_it_snow { get; set; }
    public string? chance_of_snow { get; set; }
    public int? vis_km { get; set; }
    public int? vis_miles { get; set; }
    public int? gust_mph { get; set; }
    public int? gust_kph { get; set; }
    public int? uv { get; set; }

}

public class WeatherNetApiResultForecastDayAstro
{
    public string? sunrise { get; set; }
    public string? sunset { get; set; }
    public string? moonrise { get; set; }
    public string? moonset { get; set; }
    public string? moon_phase { get; set; }
    public string? moon_illumination { get; set; }
}

public class WeatherNetApiResultForecastDayDay
{
    public int? maxtemp_c { get; set; }
    public int? maxtemp_f { get; set; }
    public int? mintemp_c { get; set; }
    public int? mintemp_f { get; set; }
    public int? avgtemp_c { get; set; }
    public int? avgtemp_f { get; set; }
    public int? maxwind_mph { get; set; }
    public int? maxwind_kph { get; set; }
    public int? totalprecip_mm { get; set; }
    public int? totalprecip_in { get; set; }
    public int? avgvis_km { get; set; }
    public int? avgvis_miles { get; set; }
    public int? avghumidity { get; set; }
    public int? daily_will_it_rain { get; set; }
    public string? daily_chance_of_rain { get; set; }
    public int? daily_will_it_snow { get; set; }
    public string? daily_chance_of_snow { get; set; }
    public WeatherNetApiResultCondition? Condition { get; set; }
    public int? uv { get; set; }
    public string? MinimumTemperatureF { get => $"{mintemp_f}°F"; }
    public string? MaximumTemperatureF { get => $"{maxtemp_f}°F"; }
    public bool WillItRain { get => daily_will_it_rain == 1 ? true : false; }
    public bool WillItSnow { get => daily_will_it_snow == 1 ? true : false; }
    public string? ChanceOfRain { get => daily_chance_of_rain; }
    public string? ChanceOfSnow { get => daily_chance_of_snow; }
    public string? MaximumWindMPH { get => $"{maxwind_mph} MPH"; }
    public string? TotalPrecipitationIN { get => $"{totalprecip_in} inches"; }

}

public class WeatherNetApiResultCondition
{
    public string? Description { get => text; }
    public string? text { get; set; }
    public string? icon { get; set; }
    public int? code { get; set; }
}