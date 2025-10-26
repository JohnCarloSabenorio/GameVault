using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameMode;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/game-mode")]
    [ApiController]
    public class GameModeController : ControllerBase
    {
        private readonly IGameModeRepo _gameModeRepo;
        public GameModeController(IGameModeRepo gameModeRepo)
        {
            _gameModeRepo = gameModeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameModeDTO>>> GetAll([FromQuery] GameModeQueryObject gameModeQueryObject)
        {
            var gameModes = await _gameModeRepo.GetAllAsync(gameModeQueryObject);

            var gameModeDtos = gameModes.Select(m => m.ToGameModeDTO());

            return Ok(gameModeDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<GameModeDTO>> GetById(long id)
        {
            var gameMode = await _gameModeRepo.GetByIdAsync(id);

            if (gameMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return Ok(gameMode.ToGameModeDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GameModeDTO>> Create(CreateGameModeDTO createGameModeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newGameMode = await _gameModeRepo.CreateAsync(createGameModeDTO);
            return CreatedAtAction(nameof(GetById), new { id = newGameMode.Id }, newGameMode.ToGameModeDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<GameModeDTO>> Update(long id, UpdateGameModeDTO updateGameModeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGameMode = await _gameModeRepo.UpdateAsync(id, updateGameModeDTO);

            if (updatedGameMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return Ok(updatedGameMode.ToGameModeDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedGameMode = await _gameModeRepo.DeleteAsync(id);

            if (deletedGameMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return NoContent();
        }
    }
}