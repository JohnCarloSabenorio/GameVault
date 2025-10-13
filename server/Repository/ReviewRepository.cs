using Microsoft.EntityFrameworkCore;
using server.Data;
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
    public async Task<List<Review>> GetAllAsync()
    {
        return await _context.Review.ToListAsync();
    }
}