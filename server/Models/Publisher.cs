using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;

namespace server.Models
{
    public class Publisher
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public DateOnly YearFounded { get; set; } = DateOnly.FromDateTime(DateTime.Now);
        public string? Country { get; set; }
        public string? Website { get; set; }
        public string? Description { get; set; }
    }
}