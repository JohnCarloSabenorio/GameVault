using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Platform
{
    public class CreatePlatformDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = ("Platform name length must be atleast 1 character long."))]
        [MaxLength(80, ErrorMessage = ("Platform name length cannot exceed 80 characters."))]
        public string? Name { get; set; }
        [Required]
        public long? Generation { get; set; }
        [MaxLength(350, ErrorMessage = ("Platform name length cannot exceed 350 characters."))]
        public string? Summary { get; set; }
        [Url]
        public string? Url { get; set; }
        public long? LogoId { get; set; }
    }
}