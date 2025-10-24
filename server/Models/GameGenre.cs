

using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

public class GameGenre
{
    public long GameId { get; set; }
    public long GenreId { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Game? Game { get; set; }
    public Genre? Genre { get; set; }
}