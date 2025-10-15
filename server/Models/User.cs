

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace server.Models;


public class User : IdentityUser
{
    public List<UserReview> UserReviews { get; set; } = new List<UserReview>();
}