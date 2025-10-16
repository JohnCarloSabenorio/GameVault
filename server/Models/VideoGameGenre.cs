

using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;

[Table("VideoGameGenres")]
public class VideoGameGenre
{
    public long VideoGameId { get; set; }
    public long GenreId { get; set; }

    public VideoGame VideoGame { get; set; }
    public Genre Genre { get; set; }
}