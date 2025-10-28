using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameCollection;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers
{
    [Route("api/game-collection")]
    [ApiController]
    public class GameCollectionController : ControllerBase
    {

        private readonly ICollectionRepo _collectionRepo;
        private readonly IGameRepo _gameRepo;
        private readonly IGameCollectionRepo _gameCollectionRepo;
        public GameCollectionController(ICollectionRepo collectionRepo, IGameRepo gameRepo, IGameCollectionRepo gameCollectionRepo)
        {
            _collectionRepo = collectionRepo;
            _gameRepo = gameRepo;
            _gameCollectionRepo = gameCollectionRepo;
        }

        [HttpGet("{collectionId:long}")]
        public async Task<ActionResult<List<Game>>> GetCollectionGames([FromRoute] long collectionId)
        {
            return await _gameCollectionRepo.GetCollectionGames(collectionId);
        }

        [HttpPost("{collectionId:long}")]
        public async Task<ActionResult<GameCollectionDTO>> Create([FromRoute] long collectionId, long gameId)
        {
            if (!await _gameRepo.GameExists(gameId))
            {
                return BadRequest("Game does not exist.");
            }

            if (!await _collectionRepo.CollectionExists(collectionId))
            {
                return BadRequest("Collection does not exist.");
            }

            if (await _gameCollectionRepo.GameCollectionExists(collectionId, gameId))
            {
                return BadRequest("Cannot add the same game collection.");
            }

            var newGameCollection = await _gameCollectionRepo.CreateAsync(collectionId, gameId);

            return CreatedAtAction(nameof(GetCollectionGames), new { collectionId = newGameCollection.CollectionId }, newGameCollection.ToGameCollectionDTO());
        }

        [HttpDelete("{collectionId:long}")]
        public async Task<IActionResult> Delete([FromRoute] long collectionId, long gameId)
        {
            var deletedGameCollection = await _gameCollectionRepo.DeleteAsync(collectionId, gameId);

            if (deletedGameCollection == null)
            {
                return NotFound("Game collection does not exist.");
            }

            return NoContent();
        }
    }
}