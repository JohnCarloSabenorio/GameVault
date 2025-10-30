using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameEngine;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{

    [Route("api/game-engine")]
    [ApiController]
    public class GameEngineController : ControllerBase
    {

        private readonly IGameRepo _gameRepo;
        private readonly IEngineRepo _engineRepo;
        private readonly IGameEngineRepo _gameEngineRepo;
        public GameEngineController(IGameRepo gameRepo, IEngineRepo engineRepo, IGameEngineRepo gameEngineRepo)
        {
            _gameRepo = gameRepo;
            _engineRepo = engineRepo;
            _gameEngineRepo = gameEngineRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Engine>>> GetGameEngines([FromRoute] long gameId)
        {
            return Ok(await _gameEngineRepo.GetGameEngines(gameId));
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GameEngineDTO>> Create([FromRoute] long gameId, long engineId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }

            if (!await _engineRepo.EngineExists(engineId))
            {
                return BadRequest("Engine does not exist.");
            }

            if (await _gameEngineRepo.GameEngineExists(gameId, engineId))
            {
                return BadRequest("Cannot add the same game engine.");
            }

            var newGameEngine = await _gameEngineRepo.CreateAsync(gameId, engineId);

            return CreatedAtAction(nameof(GetGameEngines), new { gameId = newGameEngine.GameId }, newGameEngine.ToGameEngineDTO());
        }


        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long engineId)
        {
            var deletedGameEngine = await _gameEngineRepo.DeleteAsync(gameId, engineId);

            if (deletedGameEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return NoContent();
        }
    }
}