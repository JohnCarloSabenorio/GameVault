


using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.DTOs.Review;
using server.Interfaces;
using server.Models;

[Route("api/review")]
[ApiController]
public class ReviewController : ControllerBase
{

    public readonly IReviewRepo _reviewRepo;
    public ReviewController(IReviewRepo reviewRepo)
    {
        _reviewRepo = reviewRepo;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ReviewDTO>>> GetAll()
    {
        var reviews = await _reviewRepo.GetAllAsync();

        var reviewsDTO = reviews.Select(r => r.toReviewDTO());
        return Ok(reviewsDTO);
    }

}