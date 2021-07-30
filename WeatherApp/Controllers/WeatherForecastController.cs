using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace WeatherApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        [HttpGet]
        public object Get()
        {
            var rng = new Random();

            return new
            {
                Hostname = Environment.MachineName,
                Version = "4.0.0",
                Forecast = Enumerable.Range(1, 3).Select(index => new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(index),
                    TemperatureC = rng.Next(-20, 55),
                    Summary = Summaries[rng.Next(Summaries.Length)]
                })
                .ToArray()
            };
        }
    }
}
