

using System.ComponentModel.DataAnnotations;

namespace server.Models;


public class User
{
    public long Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }
    public string? Password { get; set; }

    public List<Review> Reviews { get; set; } = new List<Review>();
}