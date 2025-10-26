using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace server.DTOs.GameMode
{
    public class UpdateGameModeDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Game mode name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Game mode name cannot exceed 80 characters.")]
        public string? Name { get; set; }
    }
}