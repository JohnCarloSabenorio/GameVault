using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Tag;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/tag")]
    [ApiController]
    public class TagController : ControllerBase
    {
        private readonly ITagRepo _tagRepo;
        public TagController(ITagRepo tagRepo)
        {
            _tagRepo = tagRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<TagDTO>>> GetAll([FromQuery] TagQueryObject tagQueryObject)
        {
            var tags = await _tagRepo.GetAllAsync(tagQueryObject);

            var tagDtos = tags.Select(t => t.ToTagDTO());

            return Ok(tagDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<TagDTO>> GetById([FromRoute] long id)
        {
            var tag = await _tagRepo.GetByIdAsync(id);

            if (tag == null)
            {
                return NotFound("Tag does not exist.");
            }

            return Ok(tag.ToTagDTO());
        }

        [HttpPost]
        public async Task<ActionResult<TagDTO>> Create(CreateTagDTO createTagDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newTag = await _tagRepo.CreateAysnc(createTagDTO);

            return Ok(newTag.ToTagDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<TagDTO>> Update([FromRoute] long id, UpdateTagDTO updateTagDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedTag = await _tagRepo.UpdateAsync(id, updateTagDTO);

            if (updatedTag == null)
            {
                return NotFound("Tag does not exist.");
            }

            return Ok(updatedTag.ToTagDTO());

        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete(long id)
        {
            var deletedTag = await _tagRepo.DeleteAsync(id);
            if (deletedTag == null)
            {
                return NotFound("Tag does not exist.");
            }

            return NoContent();
        }
    }
}