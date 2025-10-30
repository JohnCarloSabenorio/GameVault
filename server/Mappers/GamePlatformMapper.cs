using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GamePlatform;
using server.Models;

namespace server.Mappers
{
    public static class GamePlatformMapper
    {
        public static GamePlatformDTO ToGamePlatformDTO(this GamePlatform gamePlatform)
        {
            return new GamePlatformDTO { GameId = gamePlatform.GameId, PlatformId = gamePlatform.PlatformId };
        }
    }
}