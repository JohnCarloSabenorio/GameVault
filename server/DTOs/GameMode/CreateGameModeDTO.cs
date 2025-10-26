using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.GameMode
{
    public class CreateGameModeDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Game mode name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Game mode name cannot exceed 80 characters.")]
        public string? Name { get; set; }

    }
}