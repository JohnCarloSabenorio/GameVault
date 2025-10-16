


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Review;
using server.Extensions;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{

    private readonly IReviewRepo _reviewRepo;
    private readonly IVideoGameRepo _videoGameRepo;
    private readonly UserManager<User> _userManager;
    public ReviewController(IReviewRepo reviewRepo, IVideoGameRepo videoGameRepo, UserManager<User> userManager)
    {
        _reviewRepo = reviewRepo;
        _videoGameRepo = videoGameRepo;
        _userManager = userManager;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll([FromQuery] ReviewQueryObject queryObject)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var reviews = await _reviewRepo.GetAllAsync(queryObject);

        var reviewsDTO = reviews.Select(r => r.ToReviewDTO());
        return Ok(reviewsDTO);
    }

    [HttpGet("{id:long}")]

    public async Task<ActionResult<ReviewDTO>> GetById([FromRoute] long id)
    {
        var review = await _reviewRepo.GetByIdAsync(id);

        if (review == null)
        {
            return NotFound("Review does not exist");
        }

        return Ok(review.ToReviewDTO());
    }

    [HttpPost("{videoGameId:long}")]
    [Authorize]
    public async Task<IActionResult> Create([FromRoute] long videoGameId, CreateReviewDTO createReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Check if video game exists


        if (!await _videoGameRepo.VideoGameExists(videoGameId))
        {
            return BadRequest("Video game does not exist.");
        }


        // Get user 
        var email = User.GetEmail();
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return NotFound("User does not exist.");
        }

        var reviewModel = await _reviewRepo.CreateAsync(videoGameId, user.Id, createReviewDTO);

        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDTO());
    }

    [HttpPut("{id:long}")]
    [Authorize]
    public async Task<IActionResult> Update([FromRoute] long id, UpdateReviewDTO updateReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);


        // Get user 
        var email = User.GetEmail();
        var user = await _userManager.FindByEmailAsync(email);

        if (user == null)
        {
            return NotFound("User does not exist.");
        }

        var review = await _reviewRepo.UpdateAsync(id, user.Id, updateReviewDTO);

        if (review == null)
        {
            return NotFound("Review does not exist");
        }

        return Ok(review.ToReviewDTO());
    }

    [HttpDelete("{id:long}")]

    public async Task<IActionResult> Delete([FromRoute] long id)
    {
        var user = await _reviewRepo.DeleteAsync(id);

        if (user == null)
        {
            return NotFound("Review does not exist");
        }

        return NoContent();
    }
}