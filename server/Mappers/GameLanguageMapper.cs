using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameLanguage;
using server.Models;

namespace server.Mappers
{
    public static class GameLanguageMapper
    {
        public static GameLanguageDTO ToGameLanguageDTO(this GameLanguage gameLanguage)
        {
            return new GameLanguageDTO { GameId = gameLanguage.GameId, LanguageId = gameLanguage.LanguageId };
        }
    }
}