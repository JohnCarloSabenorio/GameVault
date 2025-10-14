

using server.DTOs.Review;
using server.DTOs.User;
using server.Models;

namespace server.Interfaces;

public interface IReviewRepo
{
    Task<List<Review>> GetAllAsync();

    Task<Review?> GetByIdAsync(long id);

    Task<Review> CreateAsync(Review reviewData);

    Task<Review?> UpdateAsync(long id, UpdateReviewDTO updateUserDTO);

    Task<Review?> DeleteAsync(long id);
}