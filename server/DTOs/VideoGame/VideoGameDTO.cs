
using server.DTOs.Review;
using server.Models;
namespace server.DTOs.VideoGame;


public class VideoGameDTO
{

    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Storyline { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public long Rating { get; set; }
    public long RatingCount { get; set; }
    public long TotalFavorited { get; set; }
    public long TotalPlayers { get; set; }
    public long TotalUnitSold { get; set; }
    public long Price { get; set; }
    public long? FranchiseId { get; set; }
    public long? CoverImageId { get; set; }
    public long? GameStatusId { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
}