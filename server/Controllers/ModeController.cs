using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Mode;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/mode")]
    [ApiController]
    public class ModeController : ControllerBase
    {
        private readonly IModeRepo _modeRepo;
        public ModeController(IModeRepo modeRepo)
        {
            _modeRepo = modeRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ModeDTO>>> GetAll([FromQuery] ModeQueryObject modeQueryObject)
        {
            var modes = await _modeRepo.GetAllAsync(modeQueryObject);

            var modeDtos = modes.Select(m => m.ToModeDTO());

            return Ok(modeDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ModeDTO>> GetById(long id)
        {
            var mode = await _modeRepo.GetByIdAsync(id);

            if (mode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return Ok(mode.ToModeDTO());
        }

        [HttpPost]
        public async Task<ActionResult<ModeDTO>> Create(CreateModeDTO createModeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newMode = await _modeRepo.CreateAsync(createModeDTO);
            return CreatedAtAction(nameof(GetById), new { id = newMode.Id }, newMode.ToModeDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ModeDTO>> Update(long id, UpdateModeDTO updateModeDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedMode = await _modeRepo.UpdateAsync(id, updateModeDTO);

            if (updatedMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return Ok(updatedMode.ToModeDTO());
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedMode = await _modeRepo.DeleteAsync(id);

            if (deletedMode == null)
            {
                return NotFound("Game mode does not exist.");
            }

            return NoContent();
        }
    }
}