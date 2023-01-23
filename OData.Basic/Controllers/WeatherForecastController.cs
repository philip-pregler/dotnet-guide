// using Microsoft.AspNetCore.Mvc;
// using OData.Basic.Models;
// using System.Collections.Immutable;
//
// namespace OData.Basic.Controllers
// {
//     [ApiController]
//     [Route("weather-forecast")]
//     public class WeatherForecastController : ControllerBase
//
//     {
//         private static readonly string[] Summaries = new[]
//         {
//         "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
//     };
//
//         [HttpGet]
//         public Task<WeatherForecastsResponse> GetAsync()
//         {
//             var weatherForecasts = Enumerable.Range(1, 100).Select(index => new WeatherForecast
//             {
//                 Id = index,
//                 Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                 TemperatureC = Random.Shared.Next(-20, 55),
//                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//             }).ToImmutableList();
//             return Task.FromResult(new WeatherForecastsResponse(weatherForecasts));
//         }
//
//         [HttpGet("{id}")]
//         public Task<WeatherForecastResponse> GetAsync(int id)
//         {
//             var weatherForecast = Enumerable.Range(1, 100).Select(index => new WeatherForecast
//             {
//                 Id = index,
//                 Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
//                 TemperatureC = Random.Shared.Next(-20, 55),
//                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
//             }).First(x => x.Id == id);
//             return Task.FromResult(new WeatherForecastResponse(weatherForecast));
//         }
//     }
// }