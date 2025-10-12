

using System.ComponentModel.DataAnnotations;

namespace server.Models;


public class User
{
    public long Id { get; set; }
    [Required]
    public string? Username { get; set; }
    [Required]
    public string? Email { get; set; }
    [Required]
    public string? Password { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
}