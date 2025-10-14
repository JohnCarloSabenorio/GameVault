

using server.DTOs.Review;
using server.DTOs.User;
using server.Helpers;
using server.Models;

namespace server.Interfaces;

public interface IReviewRepo
{
    Task<List<Review>> GetAllAsync(ReviewQueryObject queryObject);

    Task<Review?> GetByIdAsync(long id);

    Task<Review> CreateAsync(Review reviewData);

    Task<Review?> UpdateAsync(long id, UpdateReviewDTO updateUserDTO);

    Task<Review?> DeleteAsync(long id);
}