using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Status
{
    public class UpdateStatusDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Status name must be atleast 1 character long.")]
        [MaxLength(80, ErrorMessage = "Status name length cannot exceed 80 characters.")]
        public string StatusName { get; set; } = string.Empty;

    }
}