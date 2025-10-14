
using System.ComponentModel.DataAnnotations;

namespace server.Models;


public class Review
{
    public long Id { get; set; }
    public long? VideoGameId { get; set; }
    public bool? IsRecommended { get; set; }
    public string? Content { get; set; }
    public DateTime CreatedOn { get; set; } = DateTime.Now;

}