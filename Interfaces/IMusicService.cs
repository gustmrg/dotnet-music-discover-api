namespace MusicDiscover.Api.Interfaces;

public interface IMusicService
{
    public Task<List<string>> GetGenreByTemperature(double temperatureC);
    public void GetPlaylistByGenre(string genre);
}