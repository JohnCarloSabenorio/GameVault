using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Game;


public class CreateGameDTO
{
    [Required]
    [MinLength(1, ErrorMessage = "Game name must be atleast 1 character long.")]
    [MaxLength(366, ErrorMessage = "Game name cannot exceed 366 characters.")]
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
    public long? ImageId { get; set; }
    public long? StatusId { get; set; }
    public DateTime ReleaseDate { get; set; }

}