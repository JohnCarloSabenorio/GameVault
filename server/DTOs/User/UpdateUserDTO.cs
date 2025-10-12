

using System.ComponentModel.DataAnnotations;
namespace server.DTOs.User;

public class UpdateUserDTO
{
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }
}