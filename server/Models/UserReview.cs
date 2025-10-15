


using System.ComponentModel.DataAnnotations.Schema;

namespace server.Models;


[Table("UserReviews")]
public class UserReview
{
    public string UserId { get; set; }
    public long ReviewId { get; set; }
    public User User { get; set; }
    public Review Review { get; set; }
}