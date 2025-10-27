using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class GamePublisher
    {
        public long GameId { get; set; }
        public long PublisherId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Game? Game { get; set; }
        public Publisher? Publisher { get; set; }
    }
}