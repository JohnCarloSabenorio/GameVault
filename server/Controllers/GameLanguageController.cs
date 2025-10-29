


using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameLanguage;
using server.Interfaces;
using server.Mappers;
using server.Models;

[Route("api/game-language")]
[ApiController]
public class GameLanguageController : ControllerBase
{
    private readonly IGameRepo _gameRepo;
    private readonly ILanguageRepo _languageRepo;
    private readonly IGameLanguageRepo _gameLanguageRepo;
    public GameLanguageController(IGameRepo gameRepo, ILanguageRepo languageRepo, IGameLanguageRepo gameLanguageRepo)
    {
        _gameRepo = gameRepo;
        _languageRepo = languageRepo;
        _gameLanguageRepo = gameLanguageRepo;
    }

    [HttpGet("{gameId:long}")]
    public async Task<ActionResult<List<Language>>> GetGameLanguages([FromRoute] long gameId)
    {

        return Ok(await _gameLanguageRepo.GetGameLanguages(gameId));
    }

    [HttpPost("{gameId:long}")]
    public async Task<ActionResult<GameLanguageDTO>> Create([FromRoute] long gameId, long languageId)
    {
        if (!await _gameRepo.GameExists(gameId))
        {
            return BadRequest("Game does not exist.");
        }
        if (!await _languageRepo.LanguageExists(languageId))
        {
            return BadRequest("Language does not exist.");
        }

        if (await _gameLanguageRepo.GameLanguageExists(gameId, languageId))
        {
            return BadRequest("Cannot add the same game language.");
        }

        var newGameLanguage = await _gameLanguageRepo.CreateAsync(gameId, languageId);

        return CreatedAtAction(nameof(GetGameLanguages), new { gameId = newGameLanguage.GameId }, newGameLanguage.ToGameLanguageDTO());
    }
    [HttpDelete("{gameId:long}")]
    public async Task<IActionResult> Delete([FromRoute] long gameId, long languageId)
    {
        var deletedGameLanguage = await _gameLanguageRepo.DeleteAsync(gameId, languageId);

        if (deletedGameLanguage == null)
        {
            return NotFound("Game Language does not exist.");
        }

        return NoContent();
    }

}