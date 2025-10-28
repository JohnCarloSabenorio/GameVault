using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.DTOs.GameCollection;
using server.Models;

namespace server.Mappers
{
    public static class GameCollectionMapper
    {
        public static GameCollectionDTO ToGameCollectionDTO(this GameCollection gameCollection)
        {
            return new GameCollectionDTO { GameId = gameCollection.GameId, CollectionId = gameCollection.CollectionId };
        }
    }
}