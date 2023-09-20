using Corso.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Corso.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {

        private readonly ILogger<WeatherForecastController> _logger;
//        private readonly IWeatherData weatherData;

        public WeatherForecastController(
            ILogger<WeatherForecastController> logger)
             // ,IWeatherData weatherData)
        {
            _logger = logger;
            //this.weatherData = weatherData;
        }

        [HttpGet(Name = "GetWeatherForecast")]
        public IEnumerable<WeatherForecast> Get(
            [FromServices] IWeatherData weatherData)
        {
            return weatherData.GetWeather().ToArray();
        }
    }
}