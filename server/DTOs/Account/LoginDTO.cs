

using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Antiforgery;

namespace server.DTOs.Account;


public class LoginDTO
{
    [Required]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}