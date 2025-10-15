using System.ComponentModel.DataAnnotations;
namespace server.DTOs.Account;

public class RegisterDTO
{
    [Required]
    [MinLength(3, ErrorMessage = "Username must be at least 3 characters long.")]
    [MaxLength(30, ErrorMessage = "Username cannot be more than 30 characters long.")]
    public string? Username { get; set; }
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? Password { get; set; }
}