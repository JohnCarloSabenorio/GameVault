using System.ComponentModel.DataAnnotations;

namespace server.DTOs.GameGenre;


public class CreateGameGenreDTO
{
    [Required]
    public long GenreId { get; set; }
}