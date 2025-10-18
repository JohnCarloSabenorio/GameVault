using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.HttpResults;

namespace server.Models;


[Table("Genres")]
public class Genre
{
    public long Id { get; set; }
    public string? Name { get; set; }

    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public List<VideoGameGenre> VideoGameGenres { get; set; } = new List<VideoGameGenre>();

}