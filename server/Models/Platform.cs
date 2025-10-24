using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Platform
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public long? Generation { get; set; }
        public string? Summary { get; set; }
        public string? Url { get; set; }
        public long? LogoId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Image? Logo { get; set; }
    }
}