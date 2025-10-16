

using Microsoft.AspNetCore.Mvc;
using server.DTOs.Genre;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers;


[Route("api/genre")]
[ApiController]
public class GenreController : ControllerBase
{
    private readonly IGenreRepo _genreRepo;
    public GenreController(IGenreRepo genreRepo)
    {
        _genreRepo = genreRepo;
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<GenreDTO>>> GetAll([FromQuery] GenreQueryObject queryObject)
    {
        // Get all genres
        var genres = await _genreRepo.GetAllAsync(queryObject);
        // Convert all genre to DTO
        var genreDTOs = genres.Select(g => g.ToGenreDTO());
        // Return DTO list
        return Ok(genreDTOs);
    }

    [HttpGet("{id:long}")]

    public async Task<ActionResult<GenreDTO>> GetById([FromRoute] long id)
    {
        var genre = await _genreRepo.GetByIdAsync(id);

        if (genre == null)
        {
            return NotFound("Genre does not exist.");
        }

        return Ok(genre.ToGenreDTO());
    }


    [HttpPost]
    public async Task<ActionResult<GenreDTO>> Create(CreateGenreDTO createGenreDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        var newGenre = await _genreRepo.CreateAsync(createGenreDTO);

        return CreatedAtAction(nameof(GetById), new { id = newGenre.Id }, newGenre.ToGenreDTO());
    }

    [HttpPut("{id:long}")]
    public async Task<ActionResult<GenreDTO>> Update([FromRoute] long id, UpdateGenreDTO updateGenreDTO)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var updateGenre = await _genreRepo.UpdateAsync(id, updateGenreDTO);

        if (updateGenre == null)
        {
            return NotFound("Genre does not exist.");
        }

        return Ok(updateGenre.ToGenreDTO());
    }


    [HttpDelete("{id:long}")]
    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var genre = await _genreRepo.DeleteAsync(id);

        if (genre == null)
        {
            return NotFound("Genre does not exist.");
        }

        return NoContent();
    }


}