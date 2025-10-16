using System.ComponentModel.DataAnnotations;

using server.Models;
namespace server.DTOs.Review;



public class ReviewDTO
{

    public long VideoGameId { get; set; }

    public string UserId { get; set; }
    public bool? IsRecommended { get; set; }

    public string? Content { get; set; }

    public DateTime CreatedOn { get; set; } = DateTime.Now;
}