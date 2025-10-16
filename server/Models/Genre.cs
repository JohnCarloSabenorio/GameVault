using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("Genres")]
public class Genre
{
    public long Id { get; set; }
    public string? Name { get; set; }
    public List<VideoGameGenre> VideoGameGenres { get; set; } = new List<VideoGameGenre>();

}