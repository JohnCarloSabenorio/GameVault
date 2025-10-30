using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Tag
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<GameTag> GameTag { get; set; } = new List<GameTag>();

    }
}