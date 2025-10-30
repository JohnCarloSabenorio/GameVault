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
    public class PlatformController : ControllerBase
    {
        private readonly IPlatformRepo _platformRepo;

        public PlatformController(IPlatformRepo platformRepo)
        {
            _platformRepo = platformRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PlatformDTO>>> GetAll([FromQuery] PlatformQueryObject platformQueryObject)
        {
            var platforms = await _platformRepo.GetAllAsync(platformQueryObject);

            var platformDtos = platforms.Select(p => p.ToPlatformDTO());

            return Ok(platformDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PlatformDTO>> GetById([FromRoute] long id)
        {
            var platform = await _platformRepo.GetByIdAsync(id);

            if (platform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return Ok(platform.ToPlatformDTO());
        }

        [HttpPost]
        public async Task<ActionResult<PlatformDTO>> Create(CreatePlatformDTO createPlatformDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newPlatform = await _platformRepo.CreateAsync(createPlatformDTO);

            return CreatedAtAction(nameof(GetById), new { id = newPlatform.Id }, newPlatform.ToPlatformDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<PlatformDTO>> Update([FromRoute] long id, UpdatePlatformDTO updatePlatformDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedPlatform = await _platformRepo.UpdateAsync(id, updatePlatformDTO);
            if (updatedPlatform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return Ok(updatedPlatform.ToPlatformDTO());
        }

        [HttpDelete("{id:long}")]

        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedPlatform = await _platformRepo.DeleteAsync(id);
            if (deletedPlatform == null)
            {
                return NotFound("Game platform does not exist.");
            }

            return NoContent();
        }
    }
}