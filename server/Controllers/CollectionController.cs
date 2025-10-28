using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Collection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/collection")]
    [ApiController]
    public class CollectionController : ControllerBase
    {
        private readonly ICollectionRepo _collectionRepo;
        public CollectionController(ICollectionRepo collectionRepo)
        {
            _collectionRepo = collectionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CollectionDTO>>> GetAll([FromQuery] CollectionQueryObject collectionQueryObject)
        {
            var collections = await _collectionRepo.GetAllAsync(collectionQueryObject);

            var collectionDtos = collections.Select(c => c.ToCollectionDTO());

            return Ok(collectionDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<CollectionDTO>> GetById([FromRoute] long id)
        {
            var collection = await _collectionRepo.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound("Collection does not exist.");
            }

            return Ok(collection.ToCollectionDTO());
        }

        [HttpPost]

        public async Task<ActionResult<CollectionDTO>> Create(CreateCollectionDTO createCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCollectionData = await _collectionRepo.CreateAsync(createCollectionDTO);

            return CreatedAtAction(nameof(GetById), new { id = newCollectionData.Id }, newCollectionData.ToCollectionDTO());
        }

        [HttpPut("{id:long}")]

        public async Task<ActionResult<CollectionDTO>> Update([FromRoute] long id, UpdateCollectionDTO updateCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCollection = await _collectionRepo.UpdateAsync(id, updateCollectionDTO);

            if (updatedCollection == null)
            {
                return NotFound("Collection does not exist.");
            }

            return Ok(updatedCollection.ToCollectionDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<CollectionDTO>> Delete([FromRoute] long id)
        {

            var collection = await _collectionRepo.DeleteAsync(id);

            if (collection == null)
            {
                return NotFound("Collection does not exist.");
            }

            return NoContent();
        }

    }
}