using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GamePublisher;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{

    [Route("api/game-publisher")]
    [ApiController]
    public class GamePublisherController : ControllerBase
    {

        private readonly IGameRepo _gameRepo;
        private readonly IPublisherRepo _publisherRepo;
        private readonly IGamePublisherRepo _gamePublisherRepo;
        public GamePublisherController(IGameRepo gameRepo, IPublisherRepo publisherRepo, IGamePublisherRepo gamePublisherRepo)
        {
            _gameRepo = gameRepo;
            _publisherRepo = publisherRepo;
            _gamePublisherRepo = gamePublisherRepo;
        }

        [HttpGet("{gameId:long}")]
        public async Task<ActionResult<List<Publisher>>> GetGamePublishers([FromRoute] long gameId)
        {
            return await _gamePublisherRepo.GetGamePublishers(gameId);
        }

        [HttpDelete("{gameId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long gameId, long publisherId)
        {
            var deletedPublisher = await _gamePublisherRepo.DeleteAsync(gameId, publisherId);

            if (deletedPublisher == null)
            {
                return NotFound("Game publisher does not exist.");
            }

            return NoContent();
        }

        [HttpPost("{gameId:long}")]
        public async Task<ActionResult<GamePublisherDTO>> Create([FromRoute] long gameId, long publisherId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }

            if (!await _publisherRepo.PublisherExists(publisherId))
            {
                return BadRequest("Publisher does not exist.");
            }

            if (await _gamePublisherRepo.GamePublisherExists(gameId, publisherId))
            {
                return BadRequest("Cannot add the same game publisher.");
            }

            var newGamePublisher = await _gamePublisherRepo.CreateAsync(gameId, publisherId);

            return CreatedAtAction(nameof(GetGamePublishers), new { gameId = newGamePublisher.GameId }, newGamePublisher.ToGamePublisherDTO());
        }
    }
}