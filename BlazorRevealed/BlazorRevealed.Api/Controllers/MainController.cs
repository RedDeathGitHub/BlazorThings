using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using BlazorRevealed.Shared.Authorization;
using BlazorRevealed.Shared.Models;
using Microsoft.AspNetCore.Authorization;
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

        [Authorize(Policy = Policies.HasWeather)]
        [HttpGet("weather")]
        public IEnumerable<WeatherForecast> GetWeather()
        {
            Thread.Sleep(1000);

            var rng = new Random();
            var data = Enumerable.Range(1, 5).Select(index => new WeatherForecast
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
