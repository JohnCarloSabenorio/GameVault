using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameVideo;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-video")]
    [ApiController]
    public class GameVideoController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly IVideoRepo _videoRepo;
        private readonly IGameVideoRepo _gameVideoRepo;
        public GameVideoController(IGameRepo gameRepo, IVideoRepo videoRepo, IGameVideoRepo gameVideoRepo)
        {
            _gameRepo = gameRepo;
            _videoRepo = videoRepo;
            _gameVideoRepo = gameVideoRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Video>>> GetGameVideos([FromRoute] long gameId)
        {
            return Ok(await _gameVideoRepo.GetGameVideos(gameId));
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GameVideoDTO>> Create([FromRoute] long gameId, long videoId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }
            if (!await _videoRepo.VideoExists(videoId))
            {
                return BadRequest("Video does not exist.");
            }
            if (await _gameVideoRepo.GameVideoExists(gameId, videoId))
            {
                return BadRequest("Cannot add the same game video.");
            }

            var newGameVideo = await _gameVideoRepo.CreateAsync(gameId, videoId);
            return CreatedAtAction(nameof(GetGameVideos), new { gameId = newGameVideo.GameId }, newGameVideo.ToGameVideoDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long videoId)
        {
            var deletedGameVideo = await _gameVideoRepo.DeleteAsync(gameId, videoId);

            if (deletedGameVideo == null)
            {
                return NotFound("Game video does not exist.");
            }

            return NoContent();
        }
    }
}