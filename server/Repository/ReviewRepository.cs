using Microsoft.EntityFrameworkCore;
using server.Data;
using server.DTOs.Review;
using server.Interfaces;
using server.Models;

namespace server.Repository;

public class ReviewRepository : IReviewRepo
{

    public readonly ApplicationDBContext _context;

    public ReviewRepository(ApplicationDBContext context)
    {
        _context = context;
    }



    public async Task<Review> CreateAsync(Review reviewData)
    {
        await _context.Review.AddAsync(reviewData);
        await _context.SaveChangesAsync();

        return reviewData;
    }

    public async Task<List<Review>> GetAllAsync()
    {
        return await _context.Review.ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(long id)
    {
        return await _context.Review.FindAsync(id);
    }

    public async Task<Review?> UpdateAsync(long id, UpdateReviewDTO updateUserDTO)
    {
        var review = await _context.Review.FindAsync(id);

        if (review == null)
        {
            return null;
        }

        review.IsRecommended = updateUserDTO.IsRecommended;
        review.Content = updateUserDTO.Content;

        await _context.SaveChangesAsync();

        return review;

    }

    public async Task<Review?> DeleteAsync(long id)
    {
        var review = await _context.Review.FindAsync(id);

        if (review == null)
        {
            return null;
        }

        _context.Review.Remove(review);
        await _context.SaveChangesAsync();

        return review;
    }
}