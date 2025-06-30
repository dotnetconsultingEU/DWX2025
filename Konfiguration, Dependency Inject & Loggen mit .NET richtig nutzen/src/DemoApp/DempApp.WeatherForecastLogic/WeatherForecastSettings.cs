#nullable disable
namespace DemoApp.WeatherForecastLogic;

public class WeatherForecastSettings
{
    public int CountForecasts { get; set; } = 5;
    public int MinTemperatureC { get; set; } = -50;
    public int MaxTemperatureC { get; set; } = 65;

    public string[] Summaries { get; set; }
}