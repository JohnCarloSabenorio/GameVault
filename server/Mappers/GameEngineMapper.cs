using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameEngine;
using server.Models;

namespace server.Mappers
{
    public static class GameEngineMapper
    {
        public static GameEngineDTO ToGameEngineDTO(this GameEngine gameEngine)
        {
            return new GameEngineDTO { GameId = gameEngine.GameId, EngineId = gameEngine.EngineId };
        }
    }
}