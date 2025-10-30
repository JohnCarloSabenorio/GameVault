using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameImage;
using server.Models;

namespace server.Mappers
{
    public static class GameImageMapper
    {
        public static GameImageDTO ToGameImageDTO(this GameImage gameImage)
        {
            return new GameImageDTO { GameId = gameImage.GameId, ImageId = gameImage.ImageId };
        }
    }
}