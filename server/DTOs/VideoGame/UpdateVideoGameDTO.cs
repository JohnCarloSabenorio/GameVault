using System.ComponentModel.DataAnnotations;
namespace server.DTOs.VideoGame;


public class UpdateVideoGameDTO
{
    [Required]
    [MinLength(1, ErrorMessage = "Video game title must be atleast 1 character long.")]
    [MaxLength(366, ErrorMessage = "Video game title cannot exceed 366 characters.")]
    public string? Title { get; set; }
    [Required]
    public DateTime? CreatedOn { get; set; } = DateTime.Now;
}