using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameTag;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-tag")]
    [ApiController]
    public class GameTagController : ControllerBase
    {
        private readonly IGameRepo _gameRepo;
        private readonly ITagRepo _tagRepo;
        private readonly IGameTagRepo _gameTagRepo;
        public GameTagController(IGameRepo gameRepo, ITagRepo tagRepo, IGameTagRepo gameTagRepo)
        {
            _gameRepo = gameRepo;
            _tagRepo = tagRepo;
            _gameTagRepo = gameTagRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Tag>>> GetGameTags([FromRoute] long gameId)
        {
            return Ok(await _gameTagRepo.GetGameTags(gameId));
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GameTagDTO>> Create([FromRoute] long gameId, long tagId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }
            if (!await _tagRepo.TagExists(tagId))
            {
                return BadRequest("Tag does not exist.");
            }
            if (await _gameTagRepo.GameTagExists(gameId, tagId))
            {
                return BadRequest("Cannot add the same game tag.");
            }

            var newGameTag = await _gameTagRepo.CreateAsync(gameId, tagId);

            return CreatedAtAction(nameof(GetGameTags), new { gameId = newGameTag.GameId }, newGameTag.ToGameTagDTO());
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long tagId)
        {
            var deletedGameTag = await _gameTagRepo.DeleteAsync(gameId, tagId);

            if (deletedGameTag == null)
            {
                return NotFound("Game tag does not exist.");
            }

            return NoContent();
        }
    }
}