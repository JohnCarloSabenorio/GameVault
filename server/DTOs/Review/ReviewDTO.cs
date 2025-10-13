using System.ComponentModel.DataAnnotations;

using server.Models;
namespace server.DTOs.Review;



public class ReviewDTO
{
    [Required]

    public bool? isRecommended { get; set; }

    public string? Description { get; set; }

}