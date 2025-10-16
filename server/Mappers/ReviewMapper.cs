

using Microsoft.CodeAnalysis.CSharp.Syntax;
using server.DTOs.Review;
using server.Models;

namespace server.Mappers;

public static class ReviewMapper
{
    public static ReviewDTO ToReviewDTO(this Review review)
    {
        return new ReviewDTO { Content = review.Content, IsRecommended = review.IsRecommended, VideoGameId = review.VideoGameId, UserId = review.UserId };
    }

    public static Review ToReviewFromCreateDTO(this CreateReviewDTO createReviewDTO, long videoGameId, string userId)
    {
        return new Review { IsRecommended = createReviewDTO.IsRecommended, Content = createReviewDTO.Content, VideoGameId = videoGameId, UserId = userId };
    }

}