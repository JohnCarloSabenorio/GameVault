using Microsoft.AspNetCore.Mvc;
using server.Interfaces;

namespace server.Models;

[Route("api/video-game-genre")]
[ApiController]
public class VideoGameGenreController : ControllerBase
{
    private readonly IVideoGameRepo _videoGameRepo;
    private readonly IGenreRepo _genreRepo;
    private readonly IVideoGameGenreRepo _videoGameGenreRepo;
    public VideoGameGenreController(IVideoGameRepo videoGameRepo, IGenreRepo genreRepo, IVideoGameGenreRepo videoGameGenreRepo)
    {
        _videoGameRepo = videoGameRepo;
        _genreRepo = genreRepo;
        _videoGameGenreRepo = videoGameGenreRepo;
    }

    [HttpGet("{videoGameId:long}")]

    public async Task<ActionResult<IEnumerable<Genre>>> GetVideoGameGenres([FromRoute] long videoGameId)
    {
        var genres = await _videoGameGenreRepo.GetVideoGameGenres(videoGameId);

        return Ok(genres);
    }
}