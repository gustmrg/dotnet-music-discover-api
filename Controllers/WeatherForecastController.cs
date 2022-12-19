using Microsoft.AspNetCore.Mvc;
using MusicDiscover.Api.Interfaces;

namespace MusicDiscover.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{
    private readonly IWeatherForecastService _weatherForecastService;

    public WeatherForecastController(IWeatherForecastService weatherForecastService)
    {
        _weatherForecastService = weatherForecastService;
    }

    [HttpGet(Name = "GetWeatherForecastByCoordinates")]
    public Task<WeatherForecast> Get(double latitude, double longitude)
    {
        return _weatherForecastService.GetWeatherForecastByCoordinates(latitude, longitude);
    }
    
    // [HttpGet(Name = "GetWeatherForecastByCity")]
    // [Route("{city}")]
    // public Task<WeatherForecast> Get([FromRoute] string city)
    // {
    //     return _weatherForecastService.GetWeatherForecastByCity(city);
    // }
}