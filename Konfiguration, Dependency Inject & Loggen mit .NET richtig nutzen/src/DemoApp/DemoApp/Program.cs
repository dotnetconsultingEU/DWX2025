using DemoApp.Infrastructure;
using DemoApp.WeatherForecastLogic;
using NLog.Extensions.Logging;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddScoped<IWeatherForecast, WeatherForecastLogicDefault>();

var d = builder.Configuration.GetDebugView();
builder.Configuration.AddJsonFile(@"\\server\share\kansy.json", optional: true, reloadOnChange: false);

builder.Services.AddOptions<WeatherForecastSettings>()
    .Bind(builder.Configuration.GetSection("WeatherForecast"));

//var environment = builder.Environment.EnvironmentName;
//if (!string.IsNullOrWhiteSpace(environment))
//    builder.Configuration.AddIniFile($"appsettings.{environment}.ini");

#region Configure NLog
//string nlogConfigFileName = Path.Combine(AppContext.BaseDirectory, "nlog.config");
//if (File.Exists(nlogConfigFileName))
//{
//    builder.Services.AddLogging(b =>
//    {
//        b.AddNLog(nlogConfigFileName);
//    });
//}
#endregion



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();


app.Run();
