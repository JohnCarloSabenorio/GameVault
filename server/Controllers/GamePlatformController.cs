using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Platform;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-platform")]
    [ApiController]
    public class GamePlatformController : ControllerBase
    {
        private readonly IGamePlatformRepo _gamePlatformRepo;

        public GamePlatformController(IGamePlatformRepo gamePlatformRepo)
        {
            _gamePlatformRepo = gamePlatformRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GamePlatformDTO>>> GetAll(GamePlatformQueryObject gamePlatformQueryObject)
        {
            var platforms = await _gamePlatformRepo.GetAllAsync(gamePlatformQueryObject);

            var platformDtos = platforms.Select(p => p.ToGamePlatformDTO());

            return Ok(platformDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<GamePlatformDTO>> GetById([FromRoute] long id)
        {
            var platform = await _gamePlatformRepo.GetByIdAsync(id);

            if (platform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return Ok(platform.ToGamePlatformDTO());
        }

        [HttpPost]
        public async Task<ActionResult<GamePlatformDTO>> Create(CreateGamePlatformDTO createGamePlatformDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newPlatform = await _gamePlatformRepo.CreateAsync(createGamePlatformDTO);

            return CreatedAtAction(nameof(newPlatform), new { id = newPlatform.Id }, newPlatform.ToGamePlatformDTO());
        }
        [HttpPut("{id:long}")]
        public async Task<ActionResult<GamePlatformDTO>> Update([FromRoute] long id, UpdateGamePlatformDTO updateGamePlatformDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedPlatform = await _gamePlatformRepo.UpdateAsync(id, updateGamePlatformDTO);

            if (updatedPlatform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return Ok(updatedPlatform);
        }

        [HttpDelete("{id:long}")]

        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedPlatform = await _gamePlatformRepo.DeleteAsync(id);
            if (deletedPlatform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return NoContent();
        }
    }
}