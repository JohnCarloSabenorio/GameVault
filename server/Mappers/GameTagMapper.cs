using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameTag;
using server.Models;

namespace server.Mappers
{
    public static class GameTagMapper
    {
        public static GameTagDTO ToGameTagDTO(this GameTag gameTag)
        {
            return new GameTagDTO { GameId = gameTag.GameId, TagId = gameTag.TagId };
        }
    }
}