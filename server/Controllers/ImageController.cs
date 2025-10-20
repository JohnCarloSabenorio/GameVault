using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.Image;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageRepo _imageRepo;

        public ImageController(IImageRepo imageRepo)
        {
            _imageRepo = imageRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageDTO>>> GetAll([FromQuery] ImageQueryObject imageQueryObject)
        {
            var images = await _imageRepo.GetAllAsync(imageQueryObject);

            var imageDTOs = images.Select(i => i.ToImageDTO());

            return Ok(imageDTOs);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<ImageDTO>> GetById([FromRoute] long id)
        {
            var image = await _imageRepo.GetByIdAsync(id);

            if (image == null)
            {
                return NotFound("Image does not exist.");
            }


            return Ok(image.ToImageDTO());
        }

        [HttpPost]
        public async Task<ActionResult<ImageDTO>> Create(CreateImageDTO createImageDTO)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newImage = await _imageRepo.CreateAsync(createImageDTO);

            return CreatedAtAction(nameof(GetById), new { id = newImage.Id }, newImage.ToImageDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<ImageDTO>> Update([FromRoute] long id, UpdateImageDTO updateImageDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var newImage = await _imageRepo.UpdateAsync(id, updateImageDTO);

            if (newImage == null)
            {
                return NotFound("Image does not exist.");
            }

            return Ok(newImage.ToImageDTO());
        }


        [HttpDelete("{id:long}")]
        public async Task<IActionResult> Delete([FromRoute] long id)
        {
            var deletedImage = await _imageRepo.DeleteAsync(id);

            if (deletedImage == null)
            {
                return NotFound("Image does not exist.");
            }

            return NoContent(); 
        }


    }
}