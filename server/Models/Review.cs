using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("Reviews")]
public class Review
{
    public long Id { get; set; }
    public long VideoGameId { get; set; }
    public VideoGame VideoGame { get; set; }
    public string UserId { get; set; }
    public User User { get; set; }
    public bool? IsRecommended { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;


}