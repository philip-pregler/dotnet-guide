using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.WithVersions.WeatherForecasts.V2.Models;

namespace OData.WithVersions.WeatherForecasts.V2.Controllers
{
    [ApiController]
    [Route("odata-weather-forecast")]
    public class ODataWeatherForecastController : ODataController

    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [ApiExplorerSettings(IgnoreApi = true)]
        [EnableQuery]
        [HttpGet]   
        public IQueryable<ODataWeatherForecast> GetAsync()
        {
            return Enumerable.Range(1, 5).Select(index => new ODataWeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).AsQueryable();
        }

        [ApiExplorerSettings(IgnoreApi = true)]
        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<ODataWeatherForecast> GetAsync([FromODataUri] int key)
        {
            return SingleResult.Create(Enumerable.Range(1, 100).Select(index => new ODataWeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)]
            }).Where(x => x.Id == key).AsQueryable());
        }
    }
}