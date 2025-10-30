using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace server.DTOs.Mode
{
    public class UpdateModeDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Mode name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Mode name cannot exceed 80 characters.")]
        public string? Name { get; set; }
    }
}