


using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Review;
using server.Interfaces;
using server.Mappers;
using server.Models;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{

    public readonly IReviewRepo _reviewRepo;
    public readonly IUserRepo _userRepo;
    public ReviewController(IReviewRepo reviewRepo, IUserRepo userRepo)
    {
        _reviewRepo = reviewRepo;
        _userRepo = userRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll()
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        var reviews = await _reviewRepo.GetAllAsync();

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

    [HttpPost("{userId:long}")]

    public async Task<IActionResult> Create([FromRoute] long userId, CreateReviewDTO createReviewDTO)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        // Check if user exists
        if (!await _userRepo.UserExists(userId))
        {
            return BadRequest("User does not exist.");
        }

        var reviewModel = createReviewDTO.ToReviewFromCreateDTO(userId);

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