using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Developer
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public string? CountryOrigin { get; set; }
        public string? WebsiteUrl { get; set; }
        public string? Description { get; set; }
        // Logo
        public long? ImageId { get; set; }
        public DateOnly DateFounded { get; set; }
        public Image? Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
    }
}