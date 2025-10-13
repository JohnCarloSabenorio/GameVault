

using Microsoft.CodeAnalysis.CSharp.Syntax;
using server.DTOs.Review;
using server.Models;

public static class ReviewMapper
{
    public static ReviewDTO toReviewDTO(this Review review)
    {
        return new ReviewDTO { Description = review.Description, isRecommended = review.isRecommended };
    }
}