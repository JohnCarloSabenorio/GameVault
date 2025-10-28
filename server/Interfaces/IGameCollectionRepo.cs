using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using server.Models;

namespace server.Interfaces
{
    public interface IGameCollectionRepo
    {
        Task<List<Game>> GetCollectionGames(long collectionId);

        Task<GameCollection> CreateAsync(long collectionId, long gameId);
        Task<GameCollection?> DeleteAsync(long collectionId, long gameId);
        Task<bool> GameCollectionExists(long collectionId, long gameId);
    }
}