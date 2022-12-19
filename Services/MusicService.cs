using System.Text.Json.Serialization;
using MusicDiscover.Api.Helpers;
using MusicDiscover.Api.Interfaces;
using RestSharp;

namespace MusicDiscover.Api.Services;

public class MusicService : IMusicService
{
    private static readonly string BaseUrl = "https://api.spotify.com/v1";
    private readonly RestClient _client;

    public MusicService(string apiKey, string apiKeySecret)
    {
        var options = new RestClientOptions(BaseUrl);

        _client = new RestClient(options)
        {
            Authenticator = new SpotifyAuthenticator("https://accounts.spotify.com/api/token", apiKey, apiKeySecret)
        };
    }
    
    public async Task<List<string>> GetGenreByTemperature(double temperatureC)
    {
        var request = new RestRequest();
        
        var response = await _client.GetJsonAsync<Root>("recommendations/available-genre-seeds");
        
        return response!.genres;
    }

    public void GetPlaylistByGenre(string genre)
    {
        throw new NotImplementedException();
    }
    
    public class Root
    {
        public List<string> genres { get; set; }
    }
}