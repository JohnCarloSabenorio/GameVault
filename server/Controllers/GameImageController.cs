using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameImage;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-image")]
    [ApiController]
    public class GameImageController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly IImageRepo _imageRepo;
        private readonly IGameImageRepo _gameImageRepo;
        public GameImageController(IGameRepo gameRepo, IImageRepo imageRepo, IGameImageRepo gameImageRepo)
        {
            _gameRepo = gameRepo;
            _imageRepo = imageRepo;
            _gameImageRepo = gameImageRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Image>>> GetGameImages([FromRoute] long gameId)
        {
            return Ok(await _gameImageRepo.GetGameImages(gameId));
        }


        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GameImageDTO>> Create([FromRoute] long gameId, long imageId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }

            if (!await _imageRepo.ImageExists(imageId))
            {
                return BadRequest("Image does not exist.");
            }

            if (await _gameImageRepo.GameImageExists(gameId, imageId))
            {
                return BadRequest("Cannot add the same game image.");
            }

            var newGameImage = await _gameImageRepo.CreateAsync(gameId, imageId);

            return CreatedAtAction(nameof(GetGameImages), new { gameId = newGameImage.GameId }, newGameImage.ToGameImageDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long imageId)
        {
            var deletedGameImage = await _gameImageRepo.DeleteAsync(gameId, imageId);
            if (deletedGameImage == null)
            {
                return NotFound("Game image does not exist.");
            }

            return NoContent();
        }
    }
}