using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Tag
{
    public class CreateTagDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Tag name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Tag name cannot exceed 80 characters.")]
        public string? Name { get; set; }

    }
}