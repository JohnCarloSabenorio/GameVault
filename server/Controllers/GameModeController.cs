using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-mode")]
    [ApiController]
    public class GameModeController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly IModeRepo _modeRepo;
        private readonly IGameModeRepo _gameModeRepo;
        public GameModeController(IGameRepo gameRepo, IModeRepo modeRepo, IGameModeRepo gameModeRepo)
        {
            _gameRepo = gameRepo;
            _modeRepo = modeRepo;
            _gameModeRepo = gameModeRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Mode>>> GetGameModes([FromRoute] long gameId)
        {
            return Ok(await _gameModeRepo.GetGameModes(gameId));
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<Mode>> Create([FromRoute] long gameId, long modeId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }
            if (!await _modeRepo.ModeExists(modeId))
            {
                return BadRequest("Mode does not exist.");
            }

            if (await _gameModeRepo.GameModeExists(gameId, modeId))
            {
                return BadRequest("Cannot add the same game mode.");
            }

            var newGameMode = await _gameModeRepo.CreateAsync(gameId, modeId);

            return CreatedAtAction(nameof(GetGameModes), new { gameId = newGameMode.GameId }, newGameMode.ToGameModeDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete(long gameId, long modeId)
        {
            var deletedGameMode = await _gameModeRepo.DeleteAsync(gameId, modeId);

            if (deletedGameMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return NoContent();
        }
    }
}