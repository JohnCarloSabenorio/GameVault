using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using server.DTOs.GameEngine;
using server.Models;

namespace server.Mappers
{
    public static class GameEngineMapper
    {
        public static GameEngineDTO ToGameEngineDTO(this GameEngine gameEngine)
        {
            return new GameEngineDTO { Name = gameEngine.Name, Description = gameEngine.Description, LogoName = gameEngine.Logo?.Name };
        }

        public static GameEngine ToGameEngineFromCreateDTO(this CreateGameEngineDTO createGameEngineDTO)
        {
            return new GameEngine { Name = createGameEngineDTO.Name, Description = createGameEngineDTO.Description, LogoId = createGameEngineDTO.LogoId };
        }
    }
}