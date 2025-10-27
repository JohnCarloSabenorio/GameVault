using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameDeveloper;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{

    [Route("api/game-developer")]
    [ApiController]
    public class GameDeveloperController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly IDeveloperRepo _devRepo;
        private readonly IGameDeveloperRepo _gameDevRepo;

        public GameDeveloperController(IGameRepo gameRepo, IDeveloperRepo devRepo, IGameDeveloperRepo gameDevRepo)
        {
            _gameRepo = gameRepo;
            _devRepo = devRepo;
            _gameDevRepo = gameDevRepo;
        }


        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Developer>>> GetGameDevelopers([FromRoute] long gameId)
        {
            return await _gameDevRepo.GetGameDevelopers(gameId);
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GameDeveloperDTO>> CreateGameDeveloper([FromRoute] long gameId, long devId)
        {
            // Check if game exists
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }
            // Check if developer exists
            if (!await _devRepo.DeveloperExists(devId))
            {
                return BadRequest("Developer does not exist.");
            }
            // Check if game developer exists

            if (await _gameDevRepo.GameDeveloperExists(gameId, devId))
            {
                return BadRequest("Cannot add the same game developer.");
            }

            // Create game developer
            var newGameDeveloper = await _gameDevRepo.CreateAsync(gameId, devId);
            // return new game developer
            return CreatedAtAction(nameof(GetGameDevelopers), new { gameId = newGameDeveloper.GameId }, newGameDeveloper.ToGameDeveloperDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> DeleteGameDeveloper([FromRoute] long gameId, long devId)
        {
            var deletedGameDev = await _gameDevRepo.DeleteAsync(gameId, devId);

            if (deletedGameDev == null)
            {
                return NotFound("Game developer does not exist.");
            }

            return NoContent();
        }
    }
}