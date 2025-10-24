using Microsoft.AspNetCore.Mvc;
using server.DTOs.VideoGameGenre;
using server.Interfaces;

namespace server.Models;

[Route("api/video-game-genre")]
[ApiController]
public class VideoGameGenreController : ControllerBase
{
    private readonly IGameRepo _videoGameRepo;
    private readonly IGenreRepo _genreRepo;
    private readonly IVideoGameGenreRepo _videoGameGenreRepo;
    public VideoGameGenreController(IGameRepo videoGameRepo, IGenreRepo genreRepo, IVideoGameGenreRepo videoGameGenreRepo)
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

    [HttpPost("{videoGameId:long}")]
    public async Task<ActionResult<VideoGameGenre>> CreateVideoGameGenre([FromRoute] long videoGameId, long genreId)
    {
        // Check if video game exists
        if (!await _videoGameRepo.VideoGameExists(videoGameId))
            return BadRequest("Video game does not exist.");

        // Check if genre exists
        if (!await _genreRepo.GenreExists(genreId))
            return BadRequest("Genre does not exist.");

        // Check if video game genre already exists
        if (await _videoGameGenreRepo.VideoGameGenreExists(videoGameId, genreId))
        {
            return BadRequest("Cannot add same genre to video game.");
        }

        var newVideoGameGenre = await _videoGameGenreRepo.CreateAsync(videoGameId, genreId);

        return CreatedAtAction(nameof(GetVideoGameGenres), new { videoGameId = videoGameId }, newVideoGameGenre.ToVideoGameGenreDTO());
    }

    [HttpDelete("{videoGameId:long}")]
    public async Task<IActionResult> DeleteVideoGameGenre([FromRoute] long videoGameId, long genreId)
    {
        var videoGameGenre = await _videoGameGenreRepo.DeleteAsync(videoGameId, genreId);
        // Check if video game genre does not exists

        if (videoGameGenre == null)
        {
            return NotFound("Video game genre does not exist.");
        }

        return NoContent();
    }
}