using System.ComponentModel.DataAnnotations;

namespace server.DTOs.VideoGameGenre;


public class CreateVideoGameGenreDTO
{
    [Required]
    public long GenreId { get; set; }
}