using System.ComponentModel.DataAnnotations.Schema;
using System.Net.Sockets;

namespace server.Models;


public class Game
{
    public long Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Storyline { get; set; } = string.Empty;
    public string Summary { get; set; } = string.Empty;
    public long Rating { get; set; }
    public long RatingCount { get; set; }
    public long TotalFavorited { get; set; }
    public long TotalPlayers { get; set; }
    public long TotalUnitSold { get; set; }
    public long Price { get; set; }
    public long? FranchiseId { get; set; }
    public long? StatusId { get; set; }
    public long? ImageId { get; set; }
    public long? ParentGameId { get; set; }
    public DateTime ReleaseDate { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.Now;
    public DateTime UpdatedAt { get; set; } = DateTime.Now;
    public Franchise? Franchise { get; set; }
    public Status? Status { get; set; }
    public Image? Image { get; set; }
    public Game? ParentGame { get; set; }

    public List<Game> DlCList { get; set; } = new List<Game>();
    public List<Review> Reviews { get; set; } = new List<Review>();
    public List<GameGenre> GameGenre { get; set; } = new List<GameGenre>();
}