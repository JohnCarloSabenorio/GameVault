using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using server.DTOs.GameMode;
using server.Models;

namespace server.Mappers
{
    public static class GameModeMapper
    {
        public static GameModeDTO ToGameModeDTO(this GameMode gameMode)
        {
            return new GameModeDTO { Name = gameMode.Name };
        }

        public static GameMode ToGameModeFromCreateDTO(this CreateGameModeDTO createGameModeDTO)
        {
            return new GameMode { Name = createGameModeDTO.Name };
        }
    }
}