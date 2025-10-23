using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.VideoGameCollection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/video-game-collection")]
    [ApiController]
    public class VideoGameCollectionController : ControllerBase
    {
        private readonly IVideoGameCollectionRepo _videoGameCollectionRepo;
        public VideoGameCollectionController(IVideoGameCollectionRepo videoGameCollectionRepo)
        {
            _videoGameCollectionRepo = videoGameCollectionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoGameCollectionDTO>>> GetAll([FromQuery] VideoGameCollectionQueryObject videoGameCollectionQueryObject)
        {
            var collections = await _videoGameCollectionRepo.GetAllAsync(videoGameCollectionQueryObject);

            var collectionDtos = collections.Select(c => c.ToVideoGameCollectionDTO());

            return Ok(collectionDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<VideoGameCollectionDTO>> GetById([FromRoute] long id)
        {
            var collection = await _videoGameCollectionRepo.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound("Video game collection does not exist.");
            }

            return Ok(collection.ToVideoGameCollectionDTO());
        }

        [HttpPost]

        public async Task<ActionResult<VideoGameCollectionDTO>> Create(CreateVideoGameCollectionDTO createVideoGameCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCollectionData = await _videoGameCollectionRepo.CreateAsync(createVideoGameCollectionDTO);

            return CreatedAtAction(nameof(GetById), new { id = newCollectionData.Id }, newCollectionData.ToVideoGameCollectionDTO());
        }

        [HttpPut("{id:long}")]

        public async Task<ActionResult<VideoGameCollectionDTO>> Update([FromRoute] long id, UpdateVideoGameCollectionDTO updateVideoGameCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCollection = await _videoGameCollectionRepo.UpdateAsync(id, updateVideoGameCollectionDTO);

            if (updatedCollection == null)
            {
                return NotFound("Video game collection does not exist.");
            }

            return Ok(updatedCollection.ToVideoGameCollectionDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<VideoGameCollectionDTO>> Delete([FromRoute] long id)
        {

            var collection = await _videoGameCollectionRepo.DeleteAsync(id);

            if (collection == null)
            {
                return NotFound("Video game collection does not exist.");
            }

            return NoContent();
        }

    }
}