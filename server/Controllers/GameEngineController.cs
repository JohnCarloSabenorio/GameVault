using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameEngine;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-engine")]
    [ApiController]
    public class GameEngineController : ControllerBase
    {
        private readonly IGameEngineRepo _gameEngineRepo;
        public GameEngineController(IGameEngineRepo gameEngineRepo)
        {
            _gameEngineRepo = gameEngineRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameEngineDTO>>> GetAll(GameEngineQueryObject gameEngineQueryObject)
        {
            var gameEngines = await _gameEngineRepo.GetAllAsync(gameEngineQueryObject);

            var gameEngineDtos = gameEngines.Select(g => g.ToGameEngineDTO());

            return Ok(gameEngineDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<IEnumerable<GameEngineDTO>>> GetById([FromRoute] long id)
        {
            var gameEngine = await _gameEngineRepo.GetByIdAsync(id);

            if (gameEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return Ok(gameEngine.ToGameEngineDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GameEngineDTO>> Create(CreateGameEngineDTO createGameEngineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newGameEngine = await _gameEngineRepo.CreateAsync(createGameEngineDTO);

            return CreatedAtAction(nameof(GetById), new { id = newGameEngine.Id }, newGameEngine.ToGameEngineDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<GameEngineDTO>> Update([FromRoute] long id, UpdateGameEngineDTO updateGameEngineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedGameEngine = await _gameEngineRepo.UpdateAsync(id, updateGameEngineDTO);
            if (updatedGameEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return Ok(updatedGameEngine.ToGameEngineDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedGameEngine = await _gameEngineRepo.DeleteAsync(id);
            if (deletedGameEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return NoContent();
        }

    }
}