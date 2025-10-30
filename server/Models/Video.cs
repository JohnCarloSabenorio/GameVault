using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Video
    {
        public long Id { get; set; }
        public string? Name { get; set; }
        public List<GameVideo> GameVideo { get; set; } = new List<GameVideo>();
    }
}