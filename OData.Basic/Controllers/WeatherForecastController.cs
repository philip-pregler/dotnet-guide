using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace OData.Basic.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ODataController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        private readonly ILogger<WeatherForecastController> _logger;
            
        public WeatherForecastController(ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
        }

        [EnableQuery]
        [HttpGet]
        public IQueryable<WeatherForecast> GetAsync()
        {
            return Enumerable.Range(1, 100).Select(index => new WeatherForecast
            {
                Id = index,
                IdTwo = index + 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).AsQueryable();
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public IQueryable<WeatherForecast> GetAsync([FromODataUri] int key)
        {
            return Enumerable.Range(1, 100).Select(index => new WeatherForecast
            {
                Id = index,
                IdTwo = index + 1,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).Where(x => x.Id == key).AsQueryable();
        }
    }
}