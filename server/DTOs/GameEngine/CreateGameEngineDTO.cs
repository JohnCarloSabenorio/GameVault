using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.GameEngine
{
    public class CreateGameEngineDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Game engine name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Game engine cannot exceed 80 characters.")]
        public string? Name { get; set; }
        [MaxLength(500, ErrorMessage = "Game engine cannot exceed 500 characters.")]
        public string? Description { get; set; }
        public long? LogoId { get; set; }
    }
}