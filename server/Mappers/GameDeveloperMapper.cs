using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameDeveloper;
using server.Models;

namespace server.Mappers
{
    public static class GameDeveloperMapper
    {
        public static GameDeveloperDTO ToGameDeveloperDTO(this GameDeveloper gameDeveloper)
        {
            return new GameDeveloperDTO { GameId = gameDeveloper.GameId, DeveloperId = gameDeveloper.DeveloperId };
        }
    }
}