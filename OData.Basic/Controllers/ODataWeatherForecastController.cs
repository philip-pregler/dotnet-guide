using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Results;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using OData.Basic.Models;
using System.Collections.Immutable;

namespace OData.Basic.Controllers
{
    [ApiController]
    [Route("weather-forecast")]
    public class ODataWeatherForecastController : ODataController
    {
        private static readonly string[] Summaries = new[]
        {
        "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
    };

        [EnableQuery]
        [HttpGet]
        public IQueryable<ODataWeatherForecast> GetAsync()
        {
            return Enumerable.Range(1, 5).Select(index => new ODataWeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Cities = new List<ODataCity>() { new ODataCity { Id = 1, City = "Mannehim" } }.ToImmutableList()
            }).AsQueryable();
        }

        [EnableQuery]
        [HttpGet("{key}")]
        public SingleResult<ODataWeatherForecast> GetAsync([FromODataUri] int key)
        {
            return SingleResult.Create(Enumerable.Range(1, 100).Select(index => new ODataWeatherForecast
            {
                Id = index,
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = Summaries[Random.Shared.Next(Summaries.Length)],
                Cities = new List<ODataCity>() { new ODataCity { Id = 1, City = "Mannehim" } }.ToImmutableList()
            }).Where(x => x.Id == key).AsQueryable());
        }
    }
}