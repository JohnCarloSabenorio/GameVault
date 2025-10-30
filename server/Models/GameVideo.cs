using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class GameVideo
    {
        public long GameId { get; set; }
        public long VideoId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Game? Game { get; set; }
        public Video? Video { get; set; }
    }
}