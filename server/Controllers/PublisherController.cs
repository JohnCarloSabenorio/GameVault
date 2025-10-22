using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Publisher;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/publisher")]
    [ApiController]
    public class PublisherController : ControllerBase
    {
        private readonly IPublisherRepo _publisherRepo;
        public PublisherController(IPublisherRepo publisherRepo)
        {
            _publisherRepo = publisherRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublisherDTO>>> GetAll([FromQuery] PublisherQueryObject publisherQueryObject)
        {
            var publishers = await _publisherRepo.GetAllAsync(publisherQueryObject);

            var publisherDtos = publishers.Select(p => p.ToPublisherDTO());

            return Ok(publisherDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<PublisherDTO>> GetById([FromRoute] long id)
        {
            var publisher = await _publisherRepo.GetByIdAsync(id);

            if (publisher == null)
            {
                return NotFound("Publisher does not exist.");
            }

            return Ok(publisher.ToPublisherDTO());
        }

        [HttpPost]
        public async Task<ActionResult<PublisherDTO>> Create(CreatePublisherDTO createPublisherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var publisherData = createPublisherDTO.ToPublisherFromCreateDTO();

            return CreatedAtAction(nameof(GetById), new { id = publisherData.Id }, publisherData.ToPublisherDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<PublisherDTO>> Update([FromRoute] long id, UpdatePublisherDTO updatePublisherDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var updatedPublisher = await _publisherRepo.UpdateAsync(id, updatePublisherDTO);

            if (updatedPublisher == null)
            {
                return NotFound("Publisher does not exist.");
            }

            return Ok(updatedPublisher.ToPublisherDTO());
        }
        [HttpDelete("{id:long}")]
        public async Task<ActionResult<PublisherDTO>> Delete([FromRoute] long id)
        {
            var deletedPublisher = await _publisherRepo.DeleteAsync(id);

            if (deletedPublisher == null)
            {
                return NotFound("Publisher does not exist.");
            }

            return Ok(deletedPublisher.ToPublisherDTO());
        }
    }
}