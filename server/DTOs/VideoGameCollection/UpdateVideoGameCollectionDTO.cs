using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.VideoGameCollection
{
    public class UpdateVideoGameCollectionDTO
    {
        [Required]
        public long? UserId { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Video game collection name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Video game collection name cannot exceed 80 characters.")]
        public string Name { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}