using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;
using server.Data;
using server.DTOs.Review;
using server.Helpers;
using server.Interfaces;
using server.Mappers;
using server.Models;

namespace server.Repository;

public class ReviewRepository : IReviewRepo
{

    public readonly ApplicationDBContext _context;

    public ReviewRepository(ApplicationDBContext context)
    {
        _context = context;
    }



    public async Task<Review> CreateAsync(long videoGameId, string userId, CreateReviewDTO createReviewDTO)
    {
        var reviewData = createReviewDTO.ToReviewFromCreateDTO(videoGameId, userId);

        await _context.Review.AddAsync(reviewData);
        await _context.SaveChangesAsync();

        return reviewData;
    }

    public async Task<List<Review>> GetAllAsync(ReviewQueryObject queryObject)
    {
        var reviews = _context.Review.AsQueryable();

        if (queryObject.IsRecommended != null)
        {
            reviews = reviews.Where(r => r.IsRecommended == queryObject.IsRecommended);
        }


        var skipNumber = (queryObject.PageNumber - 1) * queryObject.PageSize;

        return await reviews.Skip(skipNumber).Take(queryObject.PageSize).ToListAsync();
    }

    public async Task<Review?> GetByIdAsync(long id)
    {
        return await _context.Review.FindAsync(id);
    }

    public async Task<Review?> UpdateAsync(long id, string userId, UpdateReviewDTO updateReviewDTO)
    {
        var review = await _context.Review.FirstOrDefaultAsync(r => r.Id == id && r.UserId == userId);

        if (review == null)
        {
            return null;
        }

        review.IsRecommended = updateReviewDTO.IsRecommended;
        review.Content = updateReviewDTO.Content;

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