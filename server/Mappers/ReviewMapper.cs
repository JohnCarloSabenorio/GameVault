

using Microsoft.CodeAnalysis.CSharp.Syntax;
using server.DTOs.Review;
using server.Models;

namespace server.Mappers;

public static class ReviewMapper
{
    public static ReviewDTO ToReviewDTO(this Review review)
    {
        return new ReviewDTO { Content = review.Content, IsRecommended = review.IsRecommended, GameId = review.GameId, CreatedBy = review.User?.UserName };
    }

    public static Review ToReviewFromCreateDTO(this CreateReviewDTO createReviewDTO, long GameId, string userId)
    {
        return new Review { IsRecommended = createReviewDTO.IsRecommended, Content = createReviewDTO.Content, GameId = GameId, UserId = userId };
    }

}