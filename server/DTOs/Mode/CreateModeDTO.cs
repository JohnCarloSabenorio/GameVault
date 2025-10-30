using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Mode
{
    public class CreateModeDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Mode name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Mode name cannot exceed 80 characters.")]
        public string? Name { get; set; }

    }
}