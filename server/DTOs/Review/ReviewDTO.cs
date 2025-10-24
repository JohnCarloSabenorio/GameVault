using System.ComponentModel.DataAnnotations;

using server.Models;
namespace server.DTOs.Review;



public class ReviewDTO
{

    public long GameId { get; set; }

    public bool? IsRecommended { get; set; }

    public string? Content { get; set; } = string.Empty;

    public string? CreatedBy { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; } = DateTime.Now;
}