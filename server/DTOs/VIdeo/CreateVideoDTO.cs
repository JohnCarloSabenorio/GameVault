using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.VIdeo
{
    public class CreateVideoDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Video name must be atleast 1 character long.")]
        [MaxLength(300, ErrorMessage = "Video name length cannot exceed 300 characters.")]
        public string? Name { get; set; }
    }
}