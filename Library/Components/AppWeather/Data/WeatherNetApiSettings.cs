namespace AppWeather;

using System.ComponentModel.DataAnnotations;

public class WeatherNetApiSettings
{
    [Required]
    public string WeatherApiKey { get; set; }

    [Required]
    public string WeatherApiUrl { get; set; }

    [Required]
    public string Query { get; set; }

    [Required]
    public int Days { get; set; }

    [Required]
    public string Aqi { get; set; }

    [Required]
    public string Alerts { get; set; }

    public override string ToString()
    {
        return $"{WeatherApiUrl}key={WeatherApiKey}&q={Query}&days={Days}&aqi={Aqi}&alerts={Alerts}";
    }
}
