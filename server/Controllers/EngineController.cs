using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Engine;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/engine")]
    [ApiController]
    public class EngineController : ControllerBase
    {
        private readonly IEngineRepo _engineRepo;
        public EngineController(IEngineRepo engineRepo)
        {
            _engineRepo = engineRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetAll([FromQuery] EngineQueryObject engineQueryObject)
        {
            var engines = await _engineRepo.GetAllAsync(engineQueryObject);

            var engineDtos = engines.Select(g => g.ToEngineDTO());

            return Ok(engineDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<IEnumerable<EngineDTO>>> GetById([FromRoute] long id)
        {
            var engine = await _engineRepo.GetByIdAsync(id);

            if (engine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return Ok(engine.ToEngineDTO());
        }

        [HttpPost]
        public async Task<ActionResult<EngineDTO>> Create(CreateEngineDTO createEngineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newEngine = await _engineRepo.CreateAsync(createEngineDTO);

            return CreatedAtAction(nameof(GetById), new { id = newEngine.Id }, newEngine.ToEngineDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<EngineDTO>> Update([FromRoute] long id, UpdateEngineDTO updateEngineDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedEngine = await _engineRepo.UpdateAsync(id, updateEngineDTO);
            if (updatedEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return Ok(updatedEngine.ToEngineDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deletedEngine = await _engineRepo.DeleteAsync(id);
            if (deletedEngine == null)
            {
                return NotFound("Game engine does not exist.");
            }

            return NoContent();
        }
    }
}