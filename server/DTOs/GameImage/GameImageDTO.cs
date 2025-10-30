using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NuGet.Protocol.Plugins;

namespace server.DTOs.GameImage
{
    public class GameImageDTO
    {
        public long GameId { get; set; }
        public long ImageId { get; set; }
    }
}