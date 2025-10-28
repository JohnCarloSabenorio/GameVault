using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class GameCollection
    {
        public long CollectionId { get; set; }
        public long GameId { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Collection? Collection { get; set; }
        public Game? Game { get; set; }

    }
}