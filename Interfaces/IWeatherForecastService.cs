namespace MusicDiscover.Api.Interfaces;

public interface IWeatherForecastService
{
    public Task<WeatherForecast> GetWeatherForecastByCity(string city);
    public Task<WeatherForecast> GetWeatherForecastByCoordinates(double lat, double lon);
}