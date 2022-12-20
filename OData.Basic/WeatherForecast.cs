using System.ComponentModel.DataAnnotations;

namespace OData.Basic
{
    public class WeatherForecast
    {
        [Key]
        public int IdTwo { get; set; }
        public int Id { get; set; }
        
        public DateOnly Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}