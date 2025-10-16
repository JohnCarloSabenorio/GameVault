using System.ComponentModel.DataAnnotations;

namespace server.DTOs.Genre;


public class UpdateGenreDTO
{
    [Required]
    [MinLength(1, ErrorMessage = "Genre name must be at least 1 character long.")]
    [MaxLength(50, ErrorMessage = "Genre name cannot exceed 50 characters.")]
    public string? Name { get; set; }
}