using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.News
{
    public class UpdateNewsDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Header length must be atleast 1 character long.")]
        [MaxLength(70, ErrorMessage = "Header length cannot exceed 70 characters.")]
        public string? Header { get; set; }
        [MaxLength(500, ErrorMessage = "Cnotent length cannot exceed 350 characters.")]
        public string? Content { get; set; }
    }
}