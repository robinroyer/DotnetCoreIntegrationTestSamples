using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace SampleApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private readonly WeatherForecastService weatherForecastService;
        public WeatherForecastController(WeatherForecastService wfService = default)
        {
            weatherForecastService = wfService;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get() => weatherForecastService.GetForecast();
    }
}
