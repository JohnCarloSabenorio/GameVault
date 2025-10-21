using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Developer
{
    public class UpdateDeveloperDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Developer name must be atleast 1 character long.")]
        [MaxLength(100, ErrorMessage = "Developer name cannot exceed over 100 characters.")]
        public string? Name { get; set; }
        public string? CountryOrigin { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
        // Logo
        public long? ImageId { get; set; }
        public DateOnly DateFounded { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    }
}