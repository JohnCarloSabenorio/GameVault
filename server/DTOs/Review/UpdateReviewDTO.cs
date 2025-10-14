
using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Review;

public class UpdateReviewDTO
{
    [Required]
    public bool? IsRecommended { get; set; }
    [MaxLength(4500, ErrorMessage = "Review content cannot exceed 4,500 characters.")]
    public string? Content { get; set; } = string.Empty;
}