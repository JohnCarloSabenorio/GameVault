using System.ComponentModel.DataAnnotations;
using server.Data;
namespace server.DTOs.User;


public class UserDTO
{

    public long Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Email { get; set; }

}