using Microsoft.AspNetCore.Mvc;
using MusicDiscover.Api.Interfaces;

namespace MusicDiscover.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class MusicsController : ControllerBase
{
    private readonly IMusicService _musicService;

    public MusicsController(IMusicService musicService)
    {
        _musicService = musicService;
    }

    [HttpGet]
    public Task<List<string>> GetGenres(double temperature)
    {
        return _musicService.GetGenreByTemperature(temperature);
    }
}