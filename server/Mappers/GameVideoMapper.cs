using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameVideo;
using server.Models;

namespace server.Mappers
{
    public static class GameVideoMapper
    {
        public static GameVideoDTO ToGameVideoDTO(this GameVideo gameVideo)
        {
            return new GameVideoDTO { GameId = gameVideo.GameId, VideoId = gameVideo.VideoId };
        }
    }
}