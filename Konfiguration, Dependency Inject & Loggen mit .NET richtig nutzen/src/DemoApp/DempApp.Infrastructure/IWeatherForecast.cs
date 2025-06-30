namespace DemoApp.Infrastructure;

public interface IWeatherForecast
{
    /// <summary>
    /// Retrieves a collection of weather forecasts.
    /// </summary>
    /// <returns>An <see cref="IEnumerable{T}"/> of <see cref="WeatherForecastDto"/> objects representing the weather forecasts.
    /// The collection will be empty if no forecasts are available.</returns>
    IEnumerable<WeatherForecastDto> GetForecasts();
}