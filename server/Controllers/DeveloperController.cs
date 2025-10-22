using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Developer;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/developer")]
    [ApiController]
    public class DeveloperController : ControllerBase
    {

        private readonly IDeveloperRepo _developerRepo;

        public DeveloperController(IDeveloperRepo developerRepo)
        {
            _developerRepo = developerRepo;
        }

        [HttpGet]
        // Get all
        public async Task<ActionResult<IEnumerable<DeveloperDTO>>> GetAll([FromQuery] DeveloperQueryObject developerQueryObject)
        {
            var devs = await _developerRepo.GetlAllAsync(developerQueryObject);

            var devDtos = devs.Select(d => d.ToDeveloperDTO());

            return Ok(devDtos);
        }
        // Get by id 

        [HttpGet("{id:long}")]
        public async Task<ActionResult<DeveloperDTO>> GetById([FromRoute] long id)
        {
            var dev = await _developerRepo.GetByIdAsync(id);
            if (dev == null)
            {
                return NotFound("Developer does not exist.");
            }

            return dev.ToDeveloperDTO();
        }

        // Create 
        [HttpPost]
        public async Task<ActionResult<DeveloperDTO>> Create(CreateDeveloperDTO createDeveloperDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newDev = await _developerRepo.CreateAsync(createDeveloperDTO);

            return CreatedAtAction(nameof(GetById), new { id = newDev.Id }, newDev.ToDeveloperDTO());
        }

        // Update 
        [HttpPut("{id:long}")]
        public async Task<ActionResult<DeveloperDTO>> Update([FromRoute] long id, UpdateDeveloperDTO updateDeveloperDTO)
        {
            var updatedDev = await _developerRepo.UpdateAsync(id, updateDeveloperDTO);
            if (updatedDev == null)
            {
                return NotFound("Developer does not exist.");
            }

            return updatedDev.ToDeveloperDTO();
        }



        // Delete

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<DeveloperDTO>> Delete([FromRoute] long id)
        {
            var deletedDev = await _developerRepo.DeleteAsync(id);
            if (deletedDev == null)
            {
                return NotFound("Developer does not exist.");
            }

            return deletedDev.ToDeveloperDTO();
        }
    }
}