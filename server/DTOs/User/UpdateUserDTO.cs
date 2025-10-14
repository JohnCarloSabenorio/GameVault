

using System.ComponentModel.DataAnnotations;
namespace server.DTOs.User;

public class UpdateUserDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
    [MaxLength(64, ErrorMessage = "Username cannot exceeed 64 characters.")]
    public string? Username { get; set; } = string.Empty;
    [Required]
    public string? Email { get; set; } = string.Empty;
    [Required]
    [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
    public string? Password { get; set; } = string.Empty;
}