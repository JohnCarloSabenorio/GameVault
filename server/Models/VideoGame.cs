using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("VideoGames")]
public class VideoGame
{
    public long Id { get; set; }
    public string? Title { get; set; }

    public string? Description { get; set; }
    public DateTime? CreatedOn { get; set; }
    public List<Review> Reviews { get; set; } = new List<Review>();

}