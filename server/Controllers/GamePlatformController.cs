using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Interfaces;
using server.Mappers;
using server.Models;
namespace server.Controllers
{
    [Route("api/game-platform")]
    [ApiController]
    public class GamePlatformController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly IPlatformRepo _platformRepo;
        private readonly IGamePlatformRepo _gamePlatformRepo;
        public GamePlatformController(IGameRepo gameRepo, IPlatformRepo platformRepo, IGamePlatformRepo gamePlatformRepo)
        {
            _gameRepo = gameRepo;
            _platformRepo = platformRepo;
            _gamePlatformRepo = gamePlatformRepo;
        }


        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Platform>>> GetGamePlatforms([FromRoute] long gameId)
        {
            return await _gamePlatformRepo.GetGamePlatforms(gameId);
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<Platform>> Create([FromRoute] long gameId, long platformId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }
            if (!await _platformRepo.PlatformExists(platformId))
            {
                return BadRequest("Platform does not exist.");
            }

            if (await _gamePlatformRepo.GamePlatformExists(gameId, platformId))
            {
                return BadRequest("Cannot add the same game platform.");
            }

            var newGamePlatform = await _gamePlatformRepo.CreateAsync(gameId, platformId);

            return CreatedAtAction(nameof(GetGamePlatforms), new { gameId = newGamePlatform.GameId }, newGamePlatform.ToGamePlatformDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long platformId)
        {
            var deletedGamePlatform = await _gamePlatformRepo.DeleteAsync(gameId, platformId);

            if (deletedGamePlatform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return NoContent();
        }
    }
}