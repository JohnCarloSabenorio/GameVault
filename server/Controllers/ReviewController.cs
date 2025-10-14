


using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Review;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{

    public readonly IReviewRepo _reviewRepo;
    public readonly IVideoGameRepo _videoGameRepo;
    public ReviewController(IReviewRepo reviewRepo, IVideoGameRepo videoGameRepo)
    {
        _reviewRepo = reviewRepo;
        _videoGameRepo = videoGameRepo;
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

    public async Task<IActionResult> Create([FromRoute] long videoGameId, CreateReviewDTO createReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Check if video game exists


        if (!await _videoGameRepo.VideoGameExists(videoGameId))
        {
            return BadRequest("User does not exist.");
        }

        var reviewModel = createReviewDTO.ToReviewFromCreateDTO(videoGameId);

        await _reviewRepo.CreateAsync(reviewModel);

        return CreatedAtAction(nameof(GetById), new { id = reviewModel.Id }, reviewModel.ToReviewDTO());
    }

    [HttpPut("{id:long}")]
    public async Task<IActionResult> Update([FromRoute] long id, UpdateReviewDTO updateReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var review = await _reviewRepo.UpdateAsync(id, updateReviewDTO);

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