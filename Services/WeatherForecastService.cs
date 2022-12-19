using MusicDiscover.Api.Interfaces;
using Newtonsoft.Json;
using RestSharp;

namespace MusicDiscover.Api.Services;

public class WeatherForecastService : IWeatherForecastService
{
    private static readonly string BaseUrl = "https://api.openweathermap.org/data/2.5";
    private readonly string _apiKey;
    private readonly RestClient _client;

    public WeatherForecastService(string apiKey)
    {
        _apiKey = apiKey;
        _client = new RestClient(BaseUrl);
    }

    public async Task<WeatherForecast> GetWeatherForecastByCity(string city)
    {
        // Requisitar por cidade
        // https://api.openweathermap.org/data/2.5/weather?q={city name}&appid={API key}
        
        // Cria uma requisição Http com os parâmetros fornecidos
        var request = new RestRequest("weather")
            .AddParameter("q", city)
            .AddParameter("appid", _apiKey)
            .AddParameter("units", "metric")
            .AddParameter("lang", "pt_br");
        
        // Executa a requisição Http e deserializa o resultado no model Root
        var response = await _client.GetAsync<Root>(request);

        // Converte o resultado da requisição no modelo WeatherForecast
        var weatherforecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Today),
            TemperatureC = response.main.temp
        };
        
        // Retorna o resultado ao usuário
        return weatherforecast;
    }

    public async Task<WeatherForecast> GetWeatherForecastByCoordinates(double lat, double lon)
    {
        // Requisitar por lat/long:
        // "https://api.openweathermap.org/data/2.5/weather?lat=35&lon=139&appid={API key}"

        // Cria uma requisição Http com os parâmetros fornecidos
        var request = new RestRequest("weather")
            .AddParameter("lat", lat)
            .AddParameter("lon", lon)
            .AddParameter("appid", _apiKey)
            .AddParameter("units", "metric")
            .AddParameter("lang", "pt_br");
        
        // Executa a requisição Http e deserializa o resultado no model Root
        var response = await _client.GetAsync<Root>(request);

        // Converte o resultado da requisição no modelo WeatherForecast
        var weatherforecast = new WeatherForecast
        {
            Date = DateOnly.FromDateTime(DateTime.Today),
            TemperatureC = response.main.temp
        };
        
        // Retorna o resultado ao usuário
        return weatherforecast;
    }

    public class Clouds
    {
        public int all { get; set; }
    }

    public class Coord
    {
        public double lon { get; set; }
        public double lat { get; set; }
    }

    public class Main
    {
        public double temp { get; set; }
        public double feels_like { get; set; }
        public double temp_min { get; set; }
        public double temp_max { get; set; }
        public int pressure { get; set; }
        public int humidity { get; set; }
        public int sea_level { get; set; }
        public int grnd_level { get; set; }
    }

    public class Rain
    {
        [JsonProperty("1h")]
        public double _1h { get; set; }
    }

    public class Root
    {
        public Coord coord { get; set; }
        public List<Weather> weather { get; set; }
        public string @base { get; set; }
        public Main main { get; set; }
        public int visibility { get; set; }
        public Wind wind { get; set; }
        public Rain rain { get; set; }
        public Clouds clouds { get; set; }
        public int dt { get; set; }
        public Sys sys { get; set; }
        public int timezone { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public int cod { get; set; }
    }

    public class Sys
    {
        public int type { get; set; }
        public int id { get; set; }
        public string country { get; set; }
        public int sunrise { get; set; }
        public int sunset { get; set; }
    }

    public class Weather
    {
        public int id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Wind
    {
        public double speed { get; set; }
        public int deg { get; set; }
        public double gust { get; set; }
    }
}