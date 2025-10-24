using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Humanizer;
using server.DTOs.Platform;
using server.Models;

namespace server.Mappers
{
    public static class GamePlatformMapper
    {
        public static GamePlatformDTO ToGamePlatformDTO(this GamePlatform gamePlatform)
        {
            return new GamePlatformDTO { Name = gamePlatform.Name, Generation = gamePlatform.Generation, Summary = gamePlatform.Summary, Url = gamePlatform.Url, Logo = gamePlatform.Logo?.ToImageDTO() };
        }

        public static GamePlatform ToGamePlatformFromCreateDTO(this CreateGamePlatformDTO createGamePlatformDTO)
        {
            return new GamePlatform { Name = createGamePlatformDTO.Name, Generation = createGamePlatformDTO.Generation, Summary = createGamePlatformDTO.Summary, Url = createGamePlatformDTO.Url, LogoId = createGamePlatformDTO.LogoId };
        }
    }
}