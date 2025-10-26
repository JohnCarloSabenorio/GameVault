using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Language
{
    public class CreateLanguageDTO
    {

        [MaxLength(300, ErrorMessage = "Language locale name cannot exceed 100 characters.")]
        public string? Locale { get; set; }
        [Required]
        [MinLength(1, ErrorMessage = "Language name must be atleast 1 character long.")]
        [MaxLength(300, ErrorMessage = "Language name cannot exceed 100 characters.")]
        public string? Name { get; set; }
        [MaxLength(300, ErrorMessage = "Language native name cannot exceed 100 characters.")]
        public string? NativeName { get; set; }
    }
}