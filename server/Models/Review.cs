using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("Reviews")]
public class Review
{
    public long Id { get; set; }
    public long GameId { get; set; }
    public string UserId { get; set; } = string.Empty;
    public bool? IsRecommended { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Game? Game { get; set; }
    public User? User { get; set; }

}