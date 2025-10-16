

using server.DTOs.Review;
using server.Helpers;
using server.Models;

namespace server.Interfaces;

public interface IReviewRepo
{
    Task<List<Review>> GetAllAsync(ReviewQueryObject queryObject);

    Task<Review?> GetByIdAsync(long id);

    Task<Review> CreateAsync(long videoGameId, string userId, CreateReviewDTO createReviewDTO);

    Task<Review?> UpdateAsync(long id, string UserId, UpdateReviewDTO updateReviewDTO);

    Task<Review?> DeleteAsync(long id);
}