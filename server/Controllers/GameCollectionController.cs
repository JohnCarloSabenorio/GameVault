using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.DTOs.GameCOllection;
using server.Helpers;
using server.Interfaces;
using server.Mappers;

namespace server.Controllers
{

    [Route("api/game-collection")]
    [ApiController]
    public class GameCollectionController : ControllerBase
    {
        private readonly IGameCollectionRepo _gameCollectionRepo;
        public GameCollectionController(IGameCollectionRepo gameCollectionRepo)
        {
            _gameCollectionRepo = gameCollectionRepo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<GameCollectionDTO>>> GetAll([FromQuery] GameCollectionQueryObject gameCollectionQueryObject)
        {
            var collections = await _gameCollectionRepo.GetAllAsync(gameCollectionQueryObject);

            var collectionDtos = collections.Select(c => c.ToGameCollectionDTO());

            return Ok(collectionDtos);
        }

        [HttpGet("{id:long}")]
        public async Task<ActionResult<GameCollectionDTO>> GetById([FromRoute] long id)
        {
            var collection = await _gameCollectionRepo.GetByIdAsync(id);

            if (collection == null)
            {
                return NotFound("Game collection does not exist.");
            }

            return Ok(collection.ToGameCollectionDTO());
        }

        [HttpPost]

        public async Task<ActionResult<GameCollectionDTO>> Create(CreateGameCollectionDTO createGameCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCollectionData = await _gameCollectionRepo.CreateAsync(createGameCollectionDTO);

            return CreatedAtAction(nameof(GetById), new { id = newCollectionData.Id }, newCollectionData.ToGameCollectionDTO());
        }

        [HttpPut("{id:long}")]

        public async Task<ActionResult<GameCollectionDTO>> Update([FromRoute] long id, UpdateGameCollectionDTO updateGameCollectionDTO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var updatedCollection = await _gameCollectionRepo.UpdateAsync(id, updateGameCollectionDTO);

            if (updatedCollection == null)
            {
                return NotFound("Game collection does not exist.");
            }

            return Ok(updatedCollection.ToGameCollectionDTO());
        }

        [HttpDelete("{id:long}")]
        public async Task<ActionResult<GameCollectionDTO>> Delete([FromRoute] long id)
        {

            var collection = await _gameCollectionRepo.DeleteAsync(id);

            if (collection == null)
            {
                return NotFound("Game collection does not exist.");
            }

            return NoContent();
        }

    }
}