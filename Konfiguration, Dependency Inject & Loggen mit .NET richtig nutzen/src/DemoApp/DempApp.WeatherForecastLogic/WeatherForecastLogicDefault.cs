using DemoApp.Infrastructure;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Runtime;


namespace DemoApp.WeatherForecastLogic;

public class WeatherForecastLogicDefault(
    IOptions<WeatherForecastSettings> settings,
    ILogger<WeatherForecastLogicDefault> logger) : IWeatherForecast
{
    private readonly WeatherForecastSettings _settings = settings.Value;

     public IEnumerable<WeatherForecastDto> GetForecasts()
     {
        logger.LogInformation("GetForecasts()");

        int n = _settings.CountForecasts;

        logger.LogInformation("CountForecasts: {n:N0}", n);

        return Enumerable.Range(1, n).Select(index => new WeatherForecastDto(
                       DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                       Random.Shared.Next(_settings.MinTemperatureC, _settings.MaxTemperatureC),
                       _settings.Summaries[Random.Shared.Next(_settings.Summaries.Length)]
        ))
        .ToArray();
    }
}
