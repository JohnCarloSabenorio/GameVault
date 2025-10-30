using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameMode;
using server.Models;

namespace server.Mappers
{
    public static class GameModeMapper
    {
        public static GameModeDTO ToGameModeDTO(this GameMode gameMode)
        {
            return new GameModeDTO { GameId = gameMode.GameId, ModeId = gameMode.ModeId };
        }
    }
}