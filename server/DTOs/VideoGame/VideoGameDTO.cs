
using server.DTOs.Review;
using server.Models;
namespace server.DTOs.VideoGame;


public class VideoGameDTO
{

    public string? Title { get; set; }
    public DateTime? CreatedOn { get; set; }
    public string? Description { get; set; }
    public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
}