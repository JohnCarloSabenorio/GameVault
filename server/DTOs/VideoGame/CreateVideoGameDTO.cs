using System.ComponentModel.DataAnnotations;

namespace server.DTOs.VideoGame;


public class CreateVideoGameDTO
{
    [Required]
    [MinLength(1, ErrorMessage = "Video game name must be atleast 1 character long.")]
    [MaxLength(366, ErrorMessage = "Video game name cannot exceed 366 characters.")]
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
}