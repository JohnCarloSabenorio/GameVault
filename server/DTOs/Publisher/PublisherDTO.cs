using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace server.DTOs.Publisher
{
    public class PublisherDTO
    {

        public string? Name { get; set; }
        public DateOnly YearFounded { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
        public long? ImageId { get; set; }
    }
}