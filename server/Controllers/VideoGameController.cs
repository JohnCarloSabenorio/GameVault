


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

    // Create post function

    // Create put function

    // Create delete function

}