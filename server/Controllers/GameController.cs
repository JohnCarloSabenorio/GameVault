


using Microsoft.AspNetCore.Mvc;
using server.DTOs.Game;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers;

[Route("api/game")]
[ApiController]
public class GameController : ControllerBase
{
    public readonly IGameRepo _gameRepo;


    public GameController(IGameRepo gameRepo)
    {
        _gameRepo = gameRepo;
    }

    // Create get all function
    [HttpGet]

    public async Task<ActionResult<IEnumerable<GameDTO>>> GetAll([FromQuery] GameQueryObject queryObject)
    {
        // Get all games
        var games = await _gameRepo.GetAllAsync(queryObject);
        // Convert all games in to DTO

        var gameDTOs = games.Select(v => v.ToGameDTO());
        // return DTOs 
        return Ok(gameDTOs);
    }

    // Create get function

    [HttpGet("{id:long}")]
    public async Task<ActionResult<GameDTO>> GetById([FromRoute] long id)
    {
        // Get game
        var game = await _gameRepo.GetByIdAsync(id);
        // Check if a game has been found
        if (game == null)
        {
            return NotFound();
        }
        // Return the DTO of the game

        return game.ToGameDTO();
    }

    // Create post function

    [HttpPost]

    public async Task<ActionResult<GameDTO>> Create(CreateGameDTO createGameDTO)
    {
        // Check if the model is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        // Create game using the GameModel
        var game = await _gameRepo.CreateAsync(createGameDTO);

        // Return game DTO
        return CreatedAtAction(nameof(GetById), new { id = game.Id }, game.ToGameDTO());
    }

    // Create put function
    [HttpPut("{id:long}")]
    public async Task<ActionResult<GameDTO>> Update([FromRoute] long id, UpdateGameDTO updateGameDTO)
    {
        // Check if the model is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var game = await _gameRepo.UpdateAsync(id, updateGameDTO);

        if (game == null)
        {
            return NotFound();
        }

        return Ok(game.ToGameDTO());
    }

    // Create delete function
    [HttpDelete("{id:long}")]

    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var game = await _gameRepo.DeleteAsync(id);

        if (game == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}