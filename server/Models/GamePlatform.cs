using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class GamePlatform
    {
        public long GameId { get; set; }
        public long PlatformId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Game? Game { get; set; }
        public Platform? Platform { get; set; }
    }
}