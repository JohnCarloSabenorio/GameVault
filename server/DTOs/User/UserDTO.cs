using System.ComponentModel.DataAnnotations;
using server.Data;
using server.DTOs.Review;
namespace server.DTOs.User;


public class UserDTO
{

    public long Id { get; set; }
    public string? Username { get; set; }
    public string? Email { get; set; }

    public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();

}