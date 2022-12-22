using System.Collections.Immutable;

namespace OData.WithVersions.WeatherForecasts.V2.Models
{
    public class WeatherForecast
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }

    public record WeatherForecastResponse(WeatherForecast WeatherForecast);
    public record WeatherForecastsResponse(IImmutableList<WeatherForecast> WeatherForecasts);


    // ODATA
    public class ODataWeatherForecast
    {
        public int Id { get; set; }

        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}