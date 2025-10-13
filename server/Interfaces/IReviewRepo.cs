

using server.Models;

namespace server.Interfaces;

public interface IReviewRepo
{
    Task<List<Review>> GetAllAsync();
}