


using Microsoft.AspNetCore.Mvc;
using server.DTOs.VideoGame;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Controllers;

[Route("api/video-game")]
[ApiController]
public class VideoGameController : ControllerBase
{
    public readonly IVideoGameRepo _videoGameRepo;


    public VideoGameController(IVideoGameRepo videoGameRepo)
    {
        _videoGameRepo = videoGameRepo;
    }

    // Create get all function
    [HttpGet]

    public async Task<ActionResult<IEnumerable<VideoGameDTO>>> GetAll([FromQuery] VideoGameQueryObject queryObject)
    {
        // Get all video games
        var videoGames = await _videoGameRepo.GetAllAsync(queryObject);
        // Convert all video games in to DTO

        var videoGameDTOs = videoGames.Select(v => v.ToVideoGameDTO());
        // return DTOs 
        return Ok(videoGameDTOs);
    }

    // Create get function

    [HttpGet("{id:long}")]
    public async Task<ActionResult<VideoGameDTO>> GetById(long id)
    {
        // Get video game
        var videoGame = await _videoGameRepo.GetByIdAsync(id);
        // Check if a video game has been found
        if (videoGame == null)
        {
            return NotFound();
        }
        // Return the DTO of the video game

        return videoGame.ToVideoGameDTO();
    }

    // Create post function

    [HttpPost]

    public async Task<ActionResult<VideoGameDTO>> Create(CreateVideoGameDTO createVideoGameDTO)
    {
        // Check if the model is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }



        // Create video game using the videoGameModel
        var videoGame = await _videoGameRepo.CreateAsync(createVideoGameDTO);

        // Return video game DTO
        return CreatedAtAction(nameof(GetById), new { id = videoGame.Id }, videoGame.ToVideoGameDTO());
    }

    // Create put function
    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update(long id, UpdateVideoGameDTO updateVideoGameDTO)
    {
        // Check if the model is valid
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var videoGame = await _videoGameRepo.UpdateAsync(id, updateVideoGameDTO);

        if (videoGame == null)
        {
            return NotFound();
        }

        return Ok(videoGame.ToVideoGameDTO());
    }


    // Create delete function

}