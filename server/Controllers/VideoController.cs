using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.VIdeo;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("{id:long}")]
    [ApiController]
    public class VideoController : ControllerBase
    {
        private readonly IVideoRepo _videoRepo;
        public VideoController(IVideoRepo videoRepo)
        {
            _videoRepo = videoRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VideoDTO>>> GetAll([FromQuery] VideoQueryObject videoQueryObject)
        {
            var videos = await _videoRepo.GetAllAsync(videoQueryObject);

            var videoDtos = videos.Select(v => v.ToVideoDTO());

            return Ok(videoDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<VideoDTO>> GetById([FromRoute] long id)
        {
            var video = await _videoRepo.GetByIdAsync(id);

            if (video == null)
            {
                return NotFound("Video does not exist.");
            }
            return Ok(video.ToVideoDTO());
        }

        [HttpPost]
        public async Task<ActionResult<VideoDTO>> Create(CreateVideoDTO createVideoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newVideo = await _videoRepo.CreateAsync(createVideoDTO);

            return Ok(newVideo.ToVideoDTO());
        }

        [HttpPut("{id:long}")]
        public async Task<ActionResult<VideoDTO>> UpdateAsync([FromRoute] long id, UpdateVIdeoDTO updateVIdeoDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var updatedVideo = await _videoRepo.UpdateAsync(id, updateVIdeoDTO);


            if (updatedVideo == null)
            {
                return NotFound("Video does not exist.");
            }

            return Ok(updatedVideo.ToVideoDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<IActionResult> DeleteAsync([FromRoute] long id)
        {
            var deletedVideo = await _videoRepo.DeleteAsync(id);

            if (deletedVideo == null)
            {
                return NotFound("Video does not exist.");
            }
            return NoContent();
        }
    }
}