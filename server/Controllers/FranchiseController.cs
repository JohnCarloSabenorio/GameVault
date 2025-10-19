using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Franchise;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/franchise")]
    [ApiController]
    public class FranchiseController : ControllerBase
    {
        private readonly IFranchiseRepo _franchiseRepo;
        public FranchiseController(IFranchiseRepo franchiseRepo)
        {
            _franchiseRepo = franchiseRepo;

        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<FranchiseDTO>>> GetAll([FromQuery] FranchiseQueryObject franchiseQueryObject)
        {
            // Get all franchises
            var franchises = await _franchiseRepo.GetAllAsync(franchiseQueryObject);
            // Convert franchises to DTOs

            var franchiseDTOs = franchises.Select(f => f.ToFranchiseDTO());
            // Return DTOs

            return Ok(franchiseDTOs);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<FranchiseDTO>> GetById([FromRoute] long id)
        {
            // Find franchise by id
            var franchise = await _franchiseRepo.GetByIdAsync(id);
            // Check if franchise exists
            if (franchise == null)
            {
                return NotFound("Franchise does not exist.");
            }
            // Convert franchise to DTO and return as ActionResult 
            return franchise.ToFranchiseDTO();
        }

        [HttpPost]
        public async Task<ActionResult<FranchiseDTO>> Create(CreateFranchiseDTO createFranchiseDTO)
        {
            // Check if the inputs are valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newFranchise = await _franchiseRepo.CreateAsync(createFranchiseDTO);

            return CreatedAtAction(nameof(GetById), new { id = newFranchise.Id }, newFranchise.ToFranchiseDTO());
        }

        [HttpPut("{id:long}")]

        public async Task<ActionResult<FranchiseDTO>> Update([FromRoute] long id, UpdateFranchiseDTO updateFranchiseDTO)
        {
            // Check if inputs are valid 
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            // Update franchise
            var updatedFranchise = await _franchiseRepo.UpdateAsync(id, updateFranchiseDTO);
            // If franchise is null, return not found
            if (updatedFranchise == null)
            {
                return NotFound("Franchise does not exist.");
            }
            // Convert to dto and return
            return updatedFranchise.ToFranchiseDTO();
        }


        [HttpDelete("{id:long}")]

        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            // Find and delete franchise
            var deletedFranchise = await _franchiseRepo.DeleteAsync(id);
            // If franchise is null return not found
            if (deletedFranchise == null)
            {
                return NotFound("Franchise does not exist.");
            }

            return NoContent();
        }
    }
}