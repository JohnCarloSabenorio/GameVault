using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using server.DTOs.Status;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Repository;

namespace server.Controllers
{

    [Route("api/status")]
    [ApiController]
    public class StatusController : ControllerBase
    {

        private readonly IStatusRepo _statusRepo;
        public StatusController(IStatusRepo statusRepo)
        {
            _statusRepo = statusRepo;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<StatusDTO>>> GetAll([FromQuery] StatusQueryObject statusQueryObject)
        {
            var statuses = await _statusRepo.GetAllAsync(statusQueryObject);

            var statusDTOs = statuses.Select(s => s.ToStatusDTO());

            return Ok(statusDTOs);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<StatusDTO>> GetById([FromRoute] long id)
        {
            // Find status
            var status = await _statusRepo.GetByIdAsync(id);
            // If status is null, return not found
            if (status == null)
            {
                return NotFound("Status does not exist.");
            }
            // return status dto
            return status.ToStatusDTO();
        }

        [HttpPost]
        public async Task<ActionResult<StatusDTO>> Create(CreateStatusDTO createStatusDTO)
        {
            // Check if inputs are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Create status
            var newStatus = await _statusRepo.CreateAsync(createStatusDTO);

            // return created status
            return CreatedAtAction(nameof(GetById), new { id = newStatus.Id }, newStatus.ToStatusDTO());
        }


        [HttpPut("{id:long}")]

        public async Task<ActionResult<StatusDTO>> Update([FromRoute] long id, UpdateStatusDTO updateStatusDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedStatus = await _statusRepo.UpdateAsync(id, updateStatusDTO);

            if (updatedStatus == null)
            {
                return NotFound("Status does not exist.");
            }

            return Ok(updatedStatus.ToStatusDTO());
        }

        [HttpDelete("{id:long}")]

        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedStatus = await _statusRepo.DeleteAsync(id);

            if (deletedStatus == null)
            {
                return NotFound("Status does not exist.");
            }

            return NoContent();
        }
    }
}