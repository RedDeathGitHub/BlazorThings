using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlazorRevealed.Shared.Dto;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace BlazorRevealed.Api.Controllers
{
    [ApiController]
    [Route("api")]
    public class MainController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<MainController> logger;

        public MainController(ILogger<MainController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("weather")]
        public IEnumerable<WeatherForecastDto> GetWeather()
        {
            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecastDto
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();

            return data;
        }

        [HttpGet("configuration")]
        public Configuration GetConfiguration()
        {
            return new Configuration
            {
                NotificationDelay = 5000,
                NotificationPeriod = 2000
            };
        }
    }
}
