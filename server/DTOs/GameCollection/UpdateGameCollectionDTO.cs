using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.GameCOllection
{
    public class UpdateGameCollectionDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Game collection name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Game collection name cannot exceed 80 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}