using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Publisher
{
    public class CreatePublisherDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Publisher name length must be atleast 1 character long.")]
        [MaxLength(350, ErrorMessage = "Publisher name length cannot exceed 350 long.")]
        public string? Name { get; set; }
        public DateOnly YearFounded { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
        public long? ImageId { get; set; }
    }
}