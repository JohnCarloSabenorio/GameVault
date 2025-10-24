using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameGenre;
using server.Interfaces;

namespace server.Models;

[Route("api/game-genre")]
[ApiController]
public class GameGenreController : ControllerBase
{
    private readonly IGameRepo _gameRepo;
    private readonly IGenreRepo _genreRepo;
    private readonly IGameGenreRepo _gameGenreRepo;
    public GameGenreController(IGameRepo gameRepo, IGenreRepo genreRepo, IGameGenreRepo gameGenreRepo)
    {
        _gameRepo = gameRepo;
        _genreRepo = genreRepo;
        _gameGenreRepo = gameGenreRepo;
    }

    [HttpGet("{gameId:long}")]

    public async Task<ActionResult<IEnumerable<Genre>>> GetGameGenres([FromRoute] long gameId)
    {
        var genres = await _gameGenreRepo.GetGameGenres(gameId);

        return Ok(genres);
    }

    [HttpPost("{gameId:long}")]
    public async Task<ActionResult<GameGenre>> CreateGameGenre([FromRoute] long gameId, long genreId)
    {
        // Check if game exists
        if (!await _gameRepo.GameExists(gameId))
            return BadRequest("Game does not exist.");

        // Check if genre exists
        if (!await _genreRepo.GenreExists(genreId))
            return BadRequest("Genre does not exist.");

        // Check if game genre already exists
        if (await _gameGenreRepo.GameGenreExists(gameId, genreId))
        {
            return BadRequest("Cannot add same genre to game.");
        }

        var newGameGenre = await _gameGenreRepo.CreateAsync(gameId, genreId);

        return CreatedAtAction(nameof(GetGameGenres), new { gameId = gameId }, newGameGenre.ToGameGenreDTO());
    }

    [HttpDelete("{gameId:long}")]
    public async Task<IActionResult> DeleteGameGenre([FromRoute] long gameId, long genreId)
    {
        var gameGenre = await _gameGenreRepo.DeleteAsync(gameId, genreId);
        // Check if game genre does not exists

        if (gameGenre == null)
        {
            return NotFound("Game genre does not exist.");
        }

        return NoContent();
    }
}