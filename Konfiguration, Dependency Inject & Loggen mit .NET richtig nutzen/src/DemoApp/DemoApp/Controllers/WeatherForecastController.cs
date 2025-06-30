using DemoApp.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace DemoApp.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController(
    IWeatherForecast weatherForecast,
    ILogger<WeatherForecastController> logger) : ControllerBase
{
    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecastDto> Get()
    {
        logger.LogInformation("Fetching weather forecasts");

        var result = weatherForecast.GetForecasts();

        return result;
    }
}
