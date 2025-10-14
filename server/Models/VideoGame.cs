namespace server.Models;


public class VideoGame
{
    public long Id { get; set; }
    public string? Title { get; set; }
    public DateTime? CreatedOn { get; set; }
    public List<Review> Reviews { get; set; } = new List<Review>();

}