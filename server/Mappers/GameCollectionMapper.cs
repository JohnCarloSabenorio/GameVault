using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameCOllection;
using server.Models;

namespace server.Mappers
{
    public static class GameCollectionMapper
    {
        public static GameCollectionDTO ToGameCollectionDTO(this GameCollection gameCollection)
        {
            return new GameCollectionDTO
            {
                Name = gameCollection.Name,
                Description = gameCollection.Description,
                CreatedAt = gameCollection.CreatedAt
            };
        }

        public static GameCollection ToGameCollectionFromCreateDTO(this CreateGameCollectionDTO createGameCollectionDTO)
        {
            return new GameCollection { UserId = createGameCollectionDTO.UserId, Name = createGameCollectionDTO.Name, Description = createGameCollectionDTO.Description };
        }
    }
}