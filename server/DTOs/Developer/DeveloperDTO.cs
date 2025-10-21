using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Developer
{
    public class DeveloperDTO
    {
        public string? Name { get; set; }
        public string? CountryOrigin { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
        // Logo
        public long? ImageId { get; set; }
        public DateOnly DateFounded { get; set; }
    }
}